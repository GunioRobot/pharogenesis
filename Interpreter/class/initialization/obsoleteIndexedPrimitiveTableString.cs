obsoleteIndexedPrimitiveTableString
	"Interpreter obsoleteIndexedPrimitiveTableString"
	"Initialize the links from the (now obsolete) indexed primitives 
	to the new named primitives."
	| table |
	table _ self obsoleteIndexedPrimitiveTable.
	^ String streamContents: [:s | 
			s nextPutAll: '{';
				 cr.
			table doWithIndex: [:primSpec :idx | 
					primSpec
						ifNil: [s nextPutAll: '{ NULL, NULL, NULL }']
						ifNotNil: [s nextPutAll: '{ "';
								 nextPutAll: primSpec first;
								 nextPutAll: '", "';
								 nextPutAll: primSpec last;
								 nextPutAll: '", NULL }'].
					idx < table size
						ifTrue: [s nextPut: $,;
								 cr]].
			s cr; nextPutAll: '}']