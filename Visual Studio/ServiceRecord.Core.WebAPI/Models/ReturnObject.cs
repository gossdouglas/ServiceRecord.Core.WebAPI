

namespace ServiceRecord.Core.WebAPI.Models
{
    public class ReturnObject<T>
    {
        //This is to indicate if the operation was successful. ie, normally some type of CRUD operation
        public bool Success { get; set; }
        //This is to indicate if the Session was properly validated
        public bool Validated { get; set; }
        //This is the redirect url if the validation was not successful
        public string? Url { get; set; }
        //This is the data from the CRUD operation
        public T? Data { get; set; }
        //
        public string? Message { get; set; }

        public int? ReturnCode { get; set; }
    }
}
