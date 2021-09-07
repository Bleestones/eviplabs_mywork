using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

/* Modified version of the example
 * https://docs.microsoft.com/en-us/dotnet/standard/serialization/examples-of-xml-serialization#purchase-order-example
 */

namespace Serialization
{
    #region Data classes
    // The XmlRoot attribute allows you to set an alternate name
    // (PurchaseOrder) for the XML element and its namespace. By
    // default, the XmlSerializer uses the class name. The attribute
    // also allows you to set the XML namespace for the element. Lastly,
    // the attribute sets the IsNullable property, which specifies whether
    // the xsi:null attribute appears if the class instance is set to
    // a null reference.
    [XmlRoot("PurchaseOrder", Namespace = "http://www.cpandl.com",
    IsNullable = false)]
    public class PurchaseOrder
    {
        public Address ShipTo;
        public string OrderDate;
        // The XmlArray attribute changes the XML element name
        // from the default of "OrderedItems" to "Items".
        [XmlArray("Items")]
        public OrderedItem[] OrderedItems;
        public decimal SubTotal;
        public decimal ShipCost;
        public decimal TotalCost;
    }

    public class Address
    {
        // The XmlAttribute attribute instructs the XmlSerializer to serialize the
        // Name field as an XML attribute instead of an XML element (XML element is
        // the default behavior).
        [XmlAttribute]
        public string Name;
        public string Line;

        // Setting the IsNullable property to false instructs the
        // XmlSerializer that the XML attribute will not appear if
        // the City field is set to a null reference.
        [XmlElement(IsNullable = false)]
        public string City;
        public string State;
        public string Zip;

        public override string ToString()
            => $"\t{ Name}\n\t{Line}\n\t{City}\t{State}\n\t{Zip}\n";
    }

    public class OrderedItem
    {
        public string ItemName;
        public string Description;
        public decimal UnitPrice;
        public int Quantity;
        public decimal LineTotal;

        // Calculate is a custom method that calculates the price per item
        // and stores the value in a field.
        public void Calculate()
        {
            LineTotal = UnitPrice * Quantity;
        }

        public override string ToString()
        {
            return $"{ItemName}\t{Description}\t{UnitPrice}\t{Quantity}\t{LineTotal}";
        }
    }
    #endregion

    public class SerializationDemo
    {
        public static void Main()
        {
            // Read and write purchase orders.
            SerializationDemo t = new SerializationDemo();
            PurchaseOrder po = t.CreateDemoPurchaseOrder();

            Console.WriteLine("--------------- XML serialization and deserialization ---------------");
            const string xmlFilename = "PurchaseOrder.xml";
            t.SerializeToXml(xmlFilename, po);
            PurchaseOrder poFromXml = t.DeserializeFromXml(xmlFilename);
            t.ShowPurchaseOrder(poFromXml);

            Console.WriteLine("--------------- JSON serialization and deserialization ---------------");
            const string jsonFilename = "PurchaseOrder.json";
            t.SerializeToJson(jsonFilename, po);
            PurchaseOrder poFromJson = t.DeserializeFromJson(jsonFilename);
            t.ShowPurchaseOrder(poFromJson);
        }

        #region Create demo data and show
        private PurchaseOrder CreateDemoPurchaseOrder()
        {
            PurchaseOrder po = new PurchaseOrder();

            // Creates an address to ship and bill to.
            Address billAddress = new Address()
            {
                Name = "Minta Márton",
                Line = "Fontos utca",
                City = "Teszvesz város",
                State = "Mozgalmas ország",
                Zip = "1234"
            };
            // Sets ShipTo and BillTo to the same addressee.
            po.ShipTo = billAddress;
            po.OrderDate = System.DateTime.Now.ToLongDateString();

            // Creates an OrderedItem.
            OrderedItem i1 = new OrderedItem()
            {
                ItemName = "Kis cucc",
                Description = "Egy egészen kicsi cucc",
                UnitPrice = (decimal)5.23,
                Quantity = 3
            };
            i1.Calculate();

            OrderedItem i2 = new OrderedItem()
            {
                ItemName = "Nagyobb cucc",
                Description = "Egy kicsit nagyobb cucc",
                UnitPrice = (decimal)7.11,
                Quantity = 2
            };
            i2.Calculate();

            // Inserts the item into the array.
            OrderedItem[] items = { i1, i2 };
            po.OrderedItems = items;
            // Calculate the total cost.
            decimal subTotal = 0;
            foreach (OrderedItem oi in items)
                subTotal += oi.LineTotal;
            po.SubTotal = subTotal;
            po.ShipCost = (decimal)12.51;
            po.TotalCost = po.SubTotal + po.ShipCost;

            return po;
        }

        private void ShowPurchaseOrder(PurchaseOrder po)
        {
            // Reads the order date.
            Console.WriteLine($"OrderDate: {po.OrderDate}");

            // Reads the shipping address.
            Address shipTo = po.ShipTo;
            Console.WriteLine($"Ship to:\n{shipTo}");
            // Reads the list of ordered items.
            OrderedItem[] items = po.OrderedItems;
            Console.WriteLine("Items to be shipped:");
            foreach (OrderedItem oi in items)
            {
                Console.WriteLine("\t" + oi);
            }
            // Reads the subtotal, shipping cost, and total cost.
            Console.WriteLine(
                $"\n\t\t\t\t\t Subtotal\t{po.SubTotal}\n\t\t\t\t\t Shipping\t{po.ShipCost}\n\t\t\t\t\t Total\t\t{po.TotalCost}");
        }
        #endregion
                       
        #region XML serialization
        private void SerializeToXml(string filename, PurchaseOrder po)
        {
            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to serialize.
            XmlSerializer serializer =
                new XmlSerializer(typeof(PurchaseOrder));
            TextWriter writer = new StreamWriter(filename);

            // Serializes the purchase order, and closes the TextWriter.
            serializer.Serialize(writer, po);
            writer.Close();
        }

        private PurchaseOrder DeserializeFromXml(string filename)
        {
            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to be deserialized.
            XmlSerializer serializer = new XmlSerializer(typeof(PurchaseOrder));

            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(filename, FileMode.Open);
            // Uses the Deserialize method to restore the object's state
            // with data from the XML document. */
            PurchaseOrder po = (PurchaseOrder)serializer.Deserialize(fs);
            return po;
        }
        #endregion

        #region JSON serialization
        private void SerializeToJson(string filename, PurchaseOrder po)
        {
            string json = JsonConvert.SerializeObject(po, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filename, json);
        }

        private PurchaseOrder DeserializeFromJson(string filename)
        {
            string json = File.ReadAllText(filename);
            PurchaseOrder po = JsonConvert.DeserializeObject<PurchaseOrder>(json);
            return po;
        }
        #endregion
    }
}
