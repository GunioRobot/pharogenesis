definitionST80
	"Refer to the comment in ClassDescription|definition."

	^ String streamContents: 
		[:strm |
		strm print: self;
			crtab;
			nextPutAll: 'instanceVariableNames: ';
			store: self instanceVariablesString]