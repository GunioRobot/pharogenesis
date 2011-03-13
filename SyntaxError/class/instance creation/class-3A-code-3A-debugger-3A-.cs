class: aClass code: aString debugger: aDebugger 
	"Answer an instance of me in which the code, aString, is to be added to 
	the class, aClass and should be debugged in the context of aDebugger."

	^self new
		setClass: aClass
		code: aString
		debugger: aDebugger