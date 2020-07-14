using Newtonsoft.Json;


//serialize objt
string jsonString = JsonConvert.SerializeObject(obj);

//deserialize objt
obj myObjt = JsonConvert.DeserializeObject<obj>(jsonString);
