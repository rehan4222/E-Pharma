using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class HelperClass
    {
        public double GetPaymentLedgerLastRemaining()
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    var remaining = context.PaymentsLedgers.
                        OrderByDescending(i => i.ID).
                        Select(r => r.Remaining).
                        First();
                    return remaining;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public double Totakworthstock(int qty, int id)
        {
            using (var context = new POS_dbEntities())
            {
                var obj = (from c in context.Products
                           where c.Product_ID == id
                           select c.Purchase_Cost).SingleOrDefault();
                return obj * qty;
            }
        }
        public int GetCompanyIdFromName(string name)
        {
            using (var context = new POS_dbEntities())
            {
                var obj = (from c in context.ProductCompanies
                           where c.CName == name
                           select c.ID).SingleOrDefault();
                return obj;
            }

        }
        public string GetCompanyNameFromID(int ID)
        {
            using (var context = new POS_dbEntities())
            {
                var obj = (from c in context.ProductCompanies
                           where c.ID ==ID
                           select c.CName).SingleOrDefault();
                return obj;
            }

        }
        public double GetmobileWorth()
        {
            using (var context = new POS_dbEntities())
            {
                var subCatFK = (from c in context.Product_Sub_Categories
                                where c.Sub_Category_Name == "Mobile"
                                select c.ID).SingleOrDefault();
                var mobileFK = (from c in context.Products
                                where c.Product_Sub_Category_FK == subCatFK
                                select c.Product_ID).ToList();
                double totalCount = 0;
                foreach (var item in mobileFK)
                {
                    var prod = (from c in context.Product_Stocks
                                where c.Product_FK == item
                                select c.Quantity).SingleOrDefault();
                    totalCount += Totakworthstock(prod, item);
                }
                return totalCount;
            }
        }
        public double GetAccessoriesWorth()
        {
            using (var context = new POS_dbEntities())
            {
                var subCatFK = (from c in context.Product_Sub_Categories
                                where c.Sub_Category_Name == "Accessories"
                                select c.ID).SingleOrDefault();
                var mobileFK = (from c in context.Products
                                where c.Product_Sub_Category_FK == subCatFK
                                select c.Product_ID).ToList();
                double totalCount = 0;
                foreach (var item in mobileFK)
                {
                    var prod = (from c in context.Product_Stocks
                                where c.Product_FK == item
                                select c.Quantity).SingleOrDefault();
                    totalCount += Totakworthstock(prod, item);
                }
                return totalCount;
            }
        }
        public double GetBankLastBalance()
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    return (context.BankRecords.OrderByDescending(i => i.ID).Select(b => b.Balance)).First();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public double GetCashLastBalance()
        {
            try
            {
                using (var context = new POS_dbEntities())
                {
                    return (context.Cashes.OrderByDescending(i => i.ID).Select(b => b.Balance)).First();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int GetSumMobilestock()
        {
            using (var context= new POS_dbEntities())
            {
                var subCatFK = (from c in context.Product_Sub_Categories
                                where c.Sub_Category_Name == "Mobile"
                                select c.ID).SingleOrDefault();
                var mobileFK = (from c in context.Products
                                where c.Product_Sub_Category_FK == subCatFK
                                select c.Product_ID).ToList();
                int totalCount = 0;
                foreach (var item in mobileFK)
                {
                    totalCount += (from c in context.Product_Stocks
                                   where c.Product_FK == item
                                   select c.Quantity).SingleOrDefault();
                }
                return totalCount;
            }
        }
        public int GetSumAccessoriestock()
        {
            using (var context = new POS_dbEntities())
            {
                var subCatFK = (from c in context.Product_Sub_Categories
                                where c.Sub_Category_Name == "Accessories"
                                select c.ID).SingleOrDefault();
                var mobileFK = (from c in context.Products
                                where c.Product_Sub_Category_FK == subCatFK
                                select c.Product_ID).ToList();
                int totalCount = 0;
                foreach (var item in mobileFK)
                {
                    totalCount += (from c in context.Product_Stocks
                                   where c.Product_FK == item
                                   select c.Quantity).SingleOrDefault();
                }
                return totalCount;
            }
        }
        public bool UserExists(string userName, string password)
        {
            using (var context= new POS_dbEntities())
            {
                var user = (from c in context.Users
                            where c.UserName == userName
                            && c.Password == password
                            select c).SingleOrDefault();
                if (user!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool InsertUser(string userName, string password)
        {
            using (var context = new POS_dbEntities())
            {
                var obj_user = new User();
                obj_user.UserName = userName;
                obj_user.Password = password;
                obj_user.Address = "Heaven";
                obj_user.Contact = "0515565252";
                obj_user.UserType = "Admin";
                context.Users.Add(obj_user);
                context.SaveChanges();
                return true;
            }
        }
        public int GetCategoryIDFromName(string name)
        {
            using (var context= new POS_dbEntities())
            {
                var catID = (from c in context.Products_Categories
                             where c.Category_Name == name
                             select c.ID).SingleOrDefault();
                return catID;
            }
        }
        public string GetExpenseCatNameFromID(int id)
        {
            using (var context=new POS_dbEntities())
            {
                var obj = (from c in context.Expense_Categories
                           where c.ID == id
                           select c.Category_Name).SingleOrDefault();
                return obj;
            }
        }
        public List<string> GetAllCats()
        {
            using (var context= new POS_dbEntities())
            {
                var cats = (from c in context.Products_Categories
                            select c.Category_Name).ToList();
                return cats;
            }
        }
        public List<string> GetSubCatsFromCatID(int id)
        {
            using (var context = new POS_dbEntities())
            {
                var cats = (from c in context.Product_Sub_Categories
                            join d in context.Products_Categories on c.Product_Category_FK equals d.ID
                            where c.Product_Category_FK== id
                            select c.Sub_Category_Name).ToList();
                return cats;
            }
        }
        public bool DeleteSubCatsForCat(int catID)
        {
            using (var context= new POS_dbEntities())
            {
                var subCats = (from c in context.Product_Sub_Categories
                               where c.Product_Category_FK == catID
                               select c).ToList();
                context.Product_Sub_Categories.RemoveRange(subCats);
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteCat(int catID)
        {
            using (var context= new POS_dbEntities())
            {
                var cat = (from c in context.Products_Categories
                           where c.ID == catID
                           select c).SingleOrDefault();
                context.Products_Categories.Remove(cat);
                context.SaveChanges();
                return true;
            }
        }
        public List<string> GetAllSubCats()
        {
            using (var context= new POS_dbEntities())
            {
                var subCats = (from c in context.Product_Sub_Categories
                               select c.Sub_Category_Name).ToList();
                return subCats;
            }
        }
        public int GetSubCategoryIDFromName(string name)
        {
            using (var context = new POS_dbEntities())
            {
                
                var catID = (from c in context.Product_Sub_Categories
                             where c.Sub_Category_Name == name
                             select c.ID).SingleOrDefault();
                return catID;
            }
        }
        public bool DeleteSubCat(int catID)
        {
            using (var context = new POS_dbEntities())
            {
                var cat = (from c in context.Product_Sub_Categories
                           where c.ID == catID
                           select c).SingleOrDefault();
                context.Product_Sub_Categories.Remove(cat);
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteProductsFromSubCat(int catID)
        {
            using (var context = new POS_dbEntities())
            {
                var cat = (from c in context.Products
                           join d in context.Product_Sub_Categories on  c.Product_Sub_Category_FK equals d.ID
                           select c).ToList();
                context.Products.RemoveRange(cat);
                context.SaveChanges();
                return true;
            }
        }
        public bool CategoryExists(string catName)
        {
            using (var context=new POS_dbEntities())
            {
                var allCats = (from c in context.Products_Categories
                               select c.Category_Name).ToList();
                if (allCats.Contains(catName)==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<Product> GetAllProducts()
        {
            using (var context= new POS_dbEntities())
            {
                var products = (from c in context.Products
                                select c).ToList();
                return products;
            }
        }
        public string GetCategoryNameFromID(int ID)
        {
            using (var context = new POS_dbEntities())
            {
                var catID = (from c in context.Products_Categories
                             where c.ID == ID
                             select c.Category_Name).SingleOrDefault();
                return catID;
            }
        }
        public int GetExpenseCategoryID(string name)
        {
            using (var context=new POS_dbEntities())
            {
                var ExpenseCategoryID = (from c in context.Expense_Categories
                                         where c.Category_Name == name
                                         select c.ID).SingleOrDefault();
                return ExpenseCategoryID;
            }
        }
        public List<string>  GetAllProductName()
        {
            using (var context = new POS_dbEntities())
            {
                var products = (from c in context.Products
                                select c.Name).ToList();
                return products;
            }
        }
        public string GetSubCategoryNameFromID(int ID)
        {
            using (var context = new POS_dbEntities())
            {
                var catID = (from c in context.Product_Sub_Categories
                             where c.ID == ID
                             select c.Sub_Category_Name).SingleOrDefault();
                return catID;
            }
        }
        public int GetCatIDFromSubCatID(int ID)
        {
            using (var context= new POS_dbEntities())
            {
                var catID = (from c in context.Product_Sub_Categories
                             where c.ID == ID
                             select c.Product_Category_FK).SingleOrDefault();
                return catID;
            }
        }
        public bool ProductExists(string productName)
        {
            using (var context = new POS_dbEntities())
            {
                var allCats = (from c in context.Products
                               select c.Name).ToList();
                if (allCats.Contains(productName) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int GetPrdocuctNameFormID(string productName)
        {
            using (var context = new POS_dbEntities())
            {
                var productID = (from c in context.Products
                             where c.Name == productName
                             select c.Product_ID).SingleOrDefault();
                return productID;
            }
        }
        public Product GetPrdocuctFormID(int productId)
        {
            using (var context = new POS_dbEntities())
            {
                var productID = (from c in context.Products
                                 where c.Product_ID == productId
                                 select c).SingleOrDefault();
                return productID;
            }
        }
        public bool DeleteProduct(int ID)
        {
            using (var context= new POS_dbEntities())
            {
                var product = (from c in context.Products
                               where c.Product_ID == ID
                               select c).SingleOrDefault();
                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
        }
        public int GetProductIDFromName(string name)
        {
            using (var context= new POS_dbEntities())
            {
                var prodID = (from c in context.Products
                              where c.Name == name
                              select c.Product_ID).SingleOrDefault();
                return prodID;
            }
        }
        public int GetSupplierIDFromName(string name)
        {
            using (var context = new POS_dbEntities())
            {
                var supplierID = (from c in context.Suppliers
                              where c.Name == name
                              select c.ID).SingleOrDefault();
                return supplierID;
            }
        }
        public SupplierDue GetSupplierDue(int supplierID)
        {
            using (var context= new POS_dbEntities())
            {
                var due = (from c in context.SupplierDues
                           where c.Supplier_FK== supplierID
                           select c).SingleOrDefault();
                return due;
            }
        }
        public List<string> GetAllSupplierNames()
        {
            using (var context= new POS_dbEntities())
            {
                var supplierList = (from c in context.Suppliers
                                    select c.Name).ToList();
                return supplierList;
            }
        }
        public string GetProductNameFromBarCode(string barCode)
        {
            using (var context= new POS_dbEntities())
            {
                var productName = (from c in context.Products
                                   where c.Barcode_Value == barCode
                                   select c.Name).SingleOrDefault();
                return productName;
            }
        }
        public List<string> GetAllBanks()
        {
            using (var context=  new POS_dbEntities())
            {
                var banks = (from c in context.Banks
                             select c.BankName).ToList();
                return banks;
            }
        }
        public int GetBankIdFromAccount(string bankAccount)
        {
            using (var context= new POS_dbEntities())
            {
                var bankID = (from c in context.Banks
                              where c.BankName == bankAccount
                              select c.ID).SingleOrDefault();
                return bankID;
            }
        }
        public  int GetCustomerID(string name)
        {
            using (var context= new POS_dbEntities())
            {
                var id = (from c in context.Customers
                          where c.Name == name
                          select c.ID).SingleOrDefault();
                return id;
            }
        }
        public CustomerDue GetCustomerDues(int id)
        {
            using (var context= new POS_dbEntities())
            {
                var due = (from c in context.CustomerDues
                           where c.ID == id
                           select c).SingleOrDefault();
                return due;
            }
        }
        public List<string> GetAllCustomerNames()
        {
            using (var context= new POS_dbEntities())
            {
                var customerList = (from c in context.Customers
                                    select c.Name).ToList();
                return customerList;
            }
        }
        public Product_Stock GetProductStock(int prodID)
        {
            using (var context= new POS_dbEntities())
            {
                var prodStock = (from c in context.Product_Stocks
                                 where c.Product_FK == prodID
                              //   && c.Supplier_FK== supplierID
                                 select c).SingleOrDefault();
                return prodStock;
            }
        }
        public int GetLastPaymentInvoice()
        {
            using (var context= new POS_dbEntities())
            {
                try
                {
                    var lastInvoice = (from c in context.Payments
                                       select c.Invoice).Max();
                    return lastInvoice + 1;
                }
                catch (Exception)
                {
                    return 1;
                }
            }
        }
        public int GetLastRecievingtInvoice()
        {
            using (var context = new POS_dbEntities())
            {
                try
                {
                    var lastInvoice = (from c in context.Recievings
                                       select c.Invoice).Max();
                    return lastInvoice + 1;
                }
                catch (Exception)
                {
                    return 1;
                }
            }
        }
        public int GetLastSaleInvoice()
        {
            using (var context = new POS_dbEntities())
            {
                try
                {
                    var lastInvoice = (from c in context.Sales
                                       select c.Invoice).Max();
                    return lastInvoice + 1;
                }
                catch (Exception)
                {
                    return 1;
                }
            }
        }
        public List<Sale> Getsalesdetail(int invoice)
        {
            using (var context=new POS_dbEntities())
            {
                var obj = (from c in context.Sales
                           where c.Invoice == invoice
                           select c).ToList();
                return obj;
            }
        }
        public List<Sale>GetSalesDetailName(string Customer)
        {
            using (var context = new POS_dbEntities())
            {
                var obj = (from c in context.Sales
                           where c.Customer_Name == Customer
                           select c).ToList();
                return obj;
            }

        }
        public string GetProductNameFromID(int id)
        {
            using (var context=new POS_dbEntities())
            {
                var obj = (from c in context.Products
                           where c.Product_ID == id
                           select c.Name).SingleOrDefault();
                return obj;
            }
        }
        public List<Purchase> GetPurchaseDetailFromInvoice(int invoice)
        {
            using (var context= new POS_dbEntities())
            {
                var purchase = (from c in context.Purchases
                                where c.Invoice == invoice
                                select c).ToList();
                return purchase;
            }
        }
        public string GetSupplierNameFromID(int Id)
        {
            using (var context= new POS_dbEntities())
            {
                var name = (from c in context.Suppliers
                            where c.ID == Id
                            select c.Name).SingleOrDefault();
                return name;
            }
        }
        public int GetSubCategoryIdFromProdId(int id)
        {
            using (var context= new POS_dbEntities())
            {
                var subCatId = (from c in context.Products
                                where c.Product_ID == id
                                select c.Product_Sub_Category_FK).SingleOrDefault();
                return subCatId;
            }
        }
        public double GetPurchaseCostFromCatID(int id)
        {
            using (var context= new POS_dbEntities())
            {
                var purchase_Cost = (from c in context.Products
                                     where c.Product_ID == id
                                     select c.Purchase_Cost).SingleOrDefault();
                return purchase_Cost;
            }
        }
        public Product GetProductDetails(int prodID)
        {
            using (var context= new POS_dbEntities())
            {
                var prod = (from c in context.Products
                            where c.Product_ID == prodID
                            select c).SingleOrDefault();
                return prod;
            }
        }
        public Payment GetPaymentDetails(int invoice)
        {
            using (var context= new POS_dbEntities())
            {
                var payment = (from c in context.Payments
                               where c.Invoice == invoice
                               select c).SingleOrDefault();
                return payment;
            }
        }
        public Recieving GetRecievingDetails(int invoice)
        {
            using (var context= new POS_dbEntities())
            {
                var recieving = (from c in context.Recievings
                                 where c.Invoice == invoice
                                 select c).SingleOrDefault();

                return recieving;
            }
        }
        public string GetCustomerName(int id)
        {
            using (var context= new POS_dbEntities())
            {
                var customer = (from c in context.Customers
                                where c.ID == id
                                select c.Name).SingleOrDefault();
                return customer;
            }
        }
        public string GetUserName(int id)
        {
            using (var context= new POS_dbEntities())
            {
                var name = (from c in context.Users
                            where c.UserID == id
                            select c.UserName).SingleOrDefault();
                return name;
            }
        }
    }
}
