errorInClass: aClass withCode: codeString doitFlag: doit
	"Open a view whose model is a syntax error. The error occurred when trying to add the given method code to the given class."

	self open:
		(self new setClass: aClass
			code: codeString
			debugger: (Debugger context: thisContext)
			doitFlag: doit).
