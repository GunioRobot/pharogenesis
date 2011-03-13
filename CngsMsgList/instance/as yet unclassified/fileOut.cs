fileOut
	"this method"
	listIndex = 0 ifFalse: [
		controller controlTerminate.
		Cursor write showWhile:
			[parent selectedClassOrMetaClass fileOutMethod: 
				self selection asSymbol].
		controller controlInitialize].