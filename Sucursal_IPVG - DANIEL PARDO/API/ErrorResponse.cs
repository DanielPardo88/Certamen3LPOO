namespace API
{

    public class ErrorResponse
    {
        public string mensaje { get; set; }
        public string tipo { get; set; }        
        public string traza { get; set; }

        public ErrorResponse(Exception ex)
        {
            mensaje = ex.Message;

            tipo = ex.GetType().Name;
            
            traza = ex.ToString();
        }
    }

}
