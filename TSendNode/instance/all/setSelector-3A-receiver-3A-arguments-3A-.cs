setSelector: aSymbol receiver: rcvrNode arguments: argList

	selector _ aSymbol.
	receiver _ rcvrNode.
	arguments _ argList asArray.
	isBuiltinOperator _ false.