handles: exception
	"This method exists to break an endless loop in Exception>>findHandlerFrom: if the exception
is invalid"
	^false