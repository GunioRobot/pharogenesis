primitiveTableDefinition
	"InterpreterSupportCode primitiveTableDefinition"
	| primitives |
	primitives _ Interpreter initialize; primitiveTable.
	^String streamContents: [:str |
	str	nextPutAll:	'// generated automatically at ';
		print:		Time now;
		nextPutAll:	' on ';
		print:		Date today;
		cr;
		nextPutAll:	'// DO NOT EDIT!!!';
		cr; cr;
		nextPutAll:	'primitive primitiveTable[MaxPrimitiveIndex + 1]= {'; cr.
	primitives doWithIndex: [:prim :index |
		str nextPutAll: '  '; print: prim.
		index == primitives size ifFalse: [str nextPut: $,].
		str cr].
	str	nextPutAll:	'};'; cr.
	]