handleFatalDrawingError: errMsg
	"Handle a fatal drawing error."
	Smalltalk isMorphic ifFalse:[^self error: errMsg]. "Can still handle it from MVC"
	Display deferUpdates: false. "Just in case"
	self primitiveError: errMsg.

	"Hm... we should jump into a 'safe' worldState here, but how do we find it?!"