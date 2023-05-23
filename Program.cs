using MapReduce;

// mapping
Mapper mapper = new Mapper();
mapper.Map("texts");
// reducing
Reducer reducer = new Reducer();
reducer.Reduce("maps");