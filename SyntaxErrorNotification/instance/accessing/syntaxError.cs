syntaxError
	^ SyntaxError new
		setClass: inClass
		code: code
		debugger: debugger
		doitFlag: doitFlag