readFrom: aStream 
	"Read the categories from the given Stream."
	aStream binary; position: 0.
	categorizer _ CelesteCategorizer new
		categoryPrototype: PluggableSet integerSet;
		pseudoCategories: {'.all.'. '.unclassified.'};
		readFrom: aStream elementReader: [:s | s nextInt32];
		yourself.