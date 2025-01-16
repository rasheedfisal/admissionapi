using System.Collections;

namespace admissionapi.api.Dtos.Responses;

 public class ReportDemo
{
    public string ProductName { get; set; }
    public string OrderId { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public string Ingredients { get; set; }
    public string ProductImage { get; set; }

    public static IList GetData()
        {
            List<ReportDemo> datas = new List<ReportDemo>();
            ReportDemo data = null;
            data = new ReportDemo()
            {
                ProductName = "Baked Chicken and Cheese",
                OrderId = "323B60",
                Price = 55,
                Category = "Non-Veg",
                Ingredients = "grilled chicken, corn and olives.",
                ProductImage = ""
            };
            datas.Add(data);
            data = new ReportDemo()
            {
                ProductName = "Chicken Delite",
                OrderId = "323B61",
                Price = 100,
                Category = "Non-Veg",
                Ingredients = "cheese, chicken chunks, onions & pineapple chunks.",
                ProductImage = ""
            };
            datas.Add(data);
            data = new ReportDemo()
            {
                ProductName = "Chicken Tikka",
                OrderId = "323B62",
                Price = 64,
                Category = "Non-Veg",
                Ingredients = "onions, grilled chicken, chicken salami & tomatoes.",
                ProductImage = ""
            };
            datas.Add(data);

            return datas;
        }

}