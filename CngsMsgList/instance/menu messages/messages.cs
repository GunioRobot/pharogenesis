messages
	"Create and schedule a message set browser on the the messages sent by 
	the selected message."

	controller controlTerminate.
	listIndex = 0 ifFalse: [
		Smalltalk showMenuThenBrowse:
			(parent selectedClassOrMetaClass compiledMethodAt: 
				self selection asSymbol ifAbsent: [controller controlInitialize.  ^ self beep]) messages asSortedCollection].
	controller controlInitialize