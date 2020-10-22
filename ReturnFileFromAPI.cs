//converting Pdf file into bytes array  
var dataBytes = File.ReadAllBytes(filePath);

//adding bytes to memory stream   
var dataStream = new MemoryStream(dataBytes);

HttpResponseMessage httpResponse = new HttpResponseMessage();

httpResponse.StatusCode = HttpStatusCode.OK;
httpResponse.Content = new StreamContent(dataStream);
httpResponse.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
httpResponse.Content.Headers.ContentDisposition.FileName = "Boletos.pdf";
httpResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

return httpResponse;
