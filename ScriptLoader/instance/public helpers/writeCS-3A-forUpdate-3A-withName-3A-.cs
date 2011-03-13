writeCS: extensionAndNumber forUpdate: updateNumber withName: aSt
	"ScriptLoader new writeCS: '-md.2929' forUpdate: 7049 withName: 'cleanUpMethods'"
	
	| str |
	str := FileDirectory default forceNewFileNamed:  updateNumber asString, 'update', aSt, '.cs'.
	self generateCS: extensionAndNumber fromUpdate: updateNumber on: str.
	str close.