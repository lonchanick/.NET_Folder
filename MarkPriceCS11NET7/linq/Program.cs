// WriteLine("Names that end up with M: ");
// NamesEndedWithM();



// WriteLine("names greater than four: ");
// var queryResults = names.Where(new Func<String, bool> (NamesLongerThanFour));
//simplifiyin query

// var queryResults = names.Where(NamesLongerThanFour);

//this can be simplified even more
// var queryResults = names
// .Where(n => n.Length > 4);

//adding orderby
// var queryResults = names
// .Where(n => n.Length > 4)
// .OrderBy(n => n.Length);

//adding thenBy
// Within a group of names of the same length, the names are sorted alphabetically by the full value of the string
// IOrderedEnumerable<string> queryResults = names //its better to use var but once finished the work its a good practice to replace var instead the current typeof
// .Where(n => n.Length > 4)
// .OrderBy(n => n.Length)
// .ThenBy(n=>n);

// foreach(var n in queryResults)
// {
//     WriteLine(n);
// }

//filtering by type
// FilteringByType<ArithmeticException>();

SetsAndBags();
