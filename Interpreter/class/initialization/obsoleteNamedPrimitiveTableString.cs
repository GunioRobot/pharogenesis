obsoleteNamedPrimitiveTableString
	"Interpreter obsoleteNamedPrimitiveTableString"
	"Initialize the links from the (now obsolete) indexed primitives 
	to the new named primitives."
	| table |
	table _ self obsoleteNamedPrimitiveTable.
	^ String streamContents: [:s | 
			s nextPutAll: '{';
				 cr.
			table do: [:primSpec | s nextPutAll: '{ "';
						 nextPutAll: primSpec first;
						 nextPutAll: '", "';
						 nextPutAll: primSpec second;
						 nextPutAll: '", "';
						 nextPutAll: primSpec third;
						 nextPutAll: '" },';
						 cr].
			s nextPutAll: '{ NULL, NULL, NULL }'.
			s cr; nextPutAll: '}']