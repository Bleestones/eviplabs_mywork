using System;
using System.Collections.Generic;
using Xunit;

namespace Storage.Test
{
    public class StorageTest
    {
        #region TEST DATA
        private Store<IStorable> myStorage = new Store<IStorable>();
        private Book exampleBook1 = new Book("1", 2, "A book", "Random");
        private Book exampleBook2 = new Book("2", 4, "B book", "Another Random");
        
        private Game exampleGame1 = new Game("4", 10, "Best Game Ever", "RPG", 2021);
        private Game exampleGame2 = new Game("5", 15, "Z game", "Shooter", 1990);

        private Game newExampleGame1 = new Game("10", 25, "Brand new game", "Adventure", 2019);

        private List<IStorable> storables = new List<IStorable>();
        
        private void FillList()
        {
            storables.Add(exampleBook1);
            storables.Add(exampleBook2);
            storables.Add(exampleGame1);
            storables.Add(exampleGame2);
        }

        #endregion
        #region CREATE
        [Fact]
        public void Insert()
        {
            myStorage.Insert(exampleGame1);
            myStorage.Insert(exampleGame2);

            Assert.Equal(2, myStorage.Count());
        }

        [Fact]
        public void InsertNegative()
        {
            Game negativeInStockGame = new Game("-1", -5, "Not enough", "none", 0);
        myStorage.Insert(negativeInStockGame);

            Assert.Equal(0, myStorage.Count());
        }

        [Fact]
        public void InsertZero()
        {
            Book zeroInStockBook = new Book("0", 0, "0", "0");
            myStorage.Insert(zeroInStockBook);

            Assert.Equal(0, myStorage.Count());
        }

        [Fact]
        public void InsertDifferentTypes()
        {
            myStorage.Insert(exampleBook1);
            myStorage.Insert(exampleGame1);

            Assert.Equal(2, myStorage.Count());
        }

        [Fact]
        public void InsertMany()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Equal(4, myStorage.Count());
        }
        [Fact]
        public void DuplicateInsert()
        {
            myStorage.Insert(exampleBook1);
            myStorage.Insert(exampleBook1);

            Assert.Equal(1, myStorage.Count());
        }

        [Fact]
        public void DuplicateIdInsert()
        {
            Book cloneExampleBook1 = new Book("1", 42, "Not A book", "Not Random");
            myStorage.Insert(exampleBook1);
            myStorage.Insert(cloneExampleBook1);

            Assert.Equal(exampleBook1, myStorage.GetById("1"));
            Assert.NotEqual(cloneExampleBook1, myStorage.GetById("1"));
        }

        [Fact]
        public void InsertNullItem()
        {
            Game nullGame = new Game();
            Assert.Throws<ArgumentNullException>(() => myStorage.Insert(nullGame));
        }

        [Fact]
        public void InsertNullIdItem()
        {
            Book nullIdBook = new Book(null, 0, "C book", "Very Random Random");
            Assert.Throws<ArgumentNullException>(() => myStorage.Insert(nullIdBook));
        }


        #endregion
        #region READ
        [Fact]
        public void ListAll()
        {
            FillList();
            myStorage.InsertMany(storables);

            List<IStorable> results = myStorage.GetAllList();

            Assert.Equal(4, results.Count);
        }

        [Fact]
        public void GetById()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Equal(exampleGame2, myStorage.GetById("5"));
        }

        [Fact]
        public void GetNonExisting()
        {
            FillList();
            myStorage.InsertMany(storables);
            Assert.Null(myStorage.GetById("42"));
        }
        #endregion
        #region UPDATE
        [Fact]
        public void BuyExisting()
        {
            FillList();
            myStorage.InsertMany(storables);
            myStorage.Buy("1", 10);

            Assert.Equal(12, myStorage.GetById("1").InStock);
        }

        [Fact]
        public void BuyNew()
        {
            FillList();
            myStorage.InsertMany(storables);
            myStorage.Buy(newExampleGame1);

            Assert.Equal(5, myStorage.Count());
            Assert.Equal(newExampleGame1, myStorage.GetById("10"));
        }

        [Fact]
        public void BuyNegative()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Throws<ArgumentException>(() => myStorage.Buy("1", -33));
        }

        [Fact]
        public void SellExisting()
        {
            FillList();
            myStorage.InsertMany(storables);
            myStorage.Sell("1", 1);

            Assert.Equal(4, myStorage.Count());
            Assert.Equal(1, myStorage.GetById("1").InStock);
        }

        [Fact]
        public void SellMore()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Throws<ArgumentException>(() => myStorage.Sell("4", 20));
        }

        [Fact]
        public void SellNonExisting()
        {
            FillList();
            myStorage.InsertMany(storables);
            myStorage.Sell("25", 100);

            Assert.Equal(4, myStorage.Count());
        }

        [Fact]
        public void SellNegative()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Throws<ArgumentException>(() => myStorage.Sell("1", -20));
        }
        #endregion
        #region DELETE
        [Fact]
        public void DeleteByIdExisting()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Equal(4, myStorage.Count());

            myStorage.Remove("1");

            Assert.Equal(3, myStorage.Count());
        }

        [Fact]
        public void DeleteByIdNonExisting()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Equal(4, myStorage.Count());

            myStorage.Remove("42");

            Assert.Equal(4, myStorage.Count());
        }
        
        [Fact]
        public void DeleteItemExisting()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Equal(4, myStorage.Count());

            myStorage.Remove(exampleBook1);

            Assert.Equal(3, myStorage.Count());
        }

        [Fact]
        public void DeleteItemNonExisting()
        {
            FillList();
            myStorage.InsertMany(storables);

            Assert.Equal(4, myStorage.Count());

            myStorage.Remove(newExampleGame1);

            Assert.Equal(4, myStorage.Count());
        }
        #endregion
    }
}
