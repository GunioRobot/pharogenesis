primitiveTableString
	"Interpreter initializePrimitiveTable primitiveTableString"
	| table |
	table _ self primitiveTable.
	^ String streamContents: [:s | 
			s nextPutAll: '{';
				 cr.
			table do: [:primSpec | s nextPutAll: primSpec;
						 nextPut: $,;
						 cr].
			s cr; nextPutAll: '}']