inClass: aClass withCode: codeString doitFlag: doitFlag 
	^ (self new
		setClass: aClass
		code: codeString
		debugger: (Debugger context: thisContext)
		doitFlag: doitFlag) signal