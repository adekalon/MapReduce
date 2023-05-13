using MapReduce;

Mapper mapper = new Mapper();
mapper.Map("input");
Reducer reducer = new Reducer();
reducer.Reduce("maps");