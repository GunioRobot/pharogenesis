browseSendersOfMessages
	"Create and schedule a message set browser on the senders of a user-chosen selector sent in the current message."

	controller controlTerminate.
	listIndex = 0 ifFalse:
		[Smalltalk showMenuThenBrowseSendersOf:
			(parent selectedClassOrMetaClass compiledMethodAt: 
				self selection asSymbol ifAbsent: [controller controlInitialize.  ^ self beep]) messages asSortedCollection].
	controller controlInitialize