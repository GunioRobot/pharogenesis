errorInClass: aClass withCode: aString 
	"Answer a standard system view whose model is an instance of me. The syntax error occurred in typing to add code, aString, to class, aClass. "

	self open: (self new setClass: aClass
						code: aString
						debugger: (Debugger context: thisContext))