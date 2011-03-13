setSelector: aSymbol receiver: rcvrNode arguments: argList isBuiltInOp: builtinFlag

	selector _ aSymbol.
	receiver _ rcvrNode.
	arguments _ argList asArray.
	isBuiltinOperator _ builtinFlag.