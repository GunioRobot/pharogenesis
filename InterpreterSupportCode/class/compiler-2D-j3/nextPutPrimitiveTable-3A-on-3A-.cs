nextPutPrimitiveTable: tricky on: file

	| prims |
	prims _ Interpreter primitiveTable.
	file nextPutAll: 'primitive_t primitiveTable['; print: (prims size + 1); nextPutAll: ']= {'; cr.
	prims do: [:prim |
		file nextPutAll: '  '.
		(tricky includesKey: prim) ifFalse: [file nextPutAll: '(primitive_t)j_'].
		file nextPutAll: prim; nextPut: $,; cr].
	file nextPutAll: '  0'; cr; nextPutAll: '};'; cr.