return: returnValue
	"Return the argument as the value of the block protected by the active exception handler."

	| handlerHomeContext |
	handlerHomeContext := ExceptionAboutToReturn signal.
	initialContext unwindTo: handlerContext.
	thisContext terminateTo: handlerContext.
	handlerHomeContext == nil
		ifFalse: [handlerContext sender swapSender: handlerHomeContext].
	^returnValue