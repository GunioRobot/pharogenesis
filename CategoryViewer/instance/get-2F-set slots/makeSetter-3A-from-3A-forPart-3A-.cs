makeSetter: arg1 from: arg2 forPart: arg3
	"Reorder the arguments for existing event handlers"
	(arg3 isMorph and:[arg3 eventHandler notNil]) ifTrue:[arg3 eventHandler fixReversedValueMessages].	
	^self makeSetter: arg1 event: arg2 from: arg3