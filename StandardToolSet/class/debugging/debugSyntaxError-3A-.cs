debugSyntaxError: anError
	"Handle a syntax error"
	| notifier |
	notifier :=  SyntaxError new
		setClass: anError errorClass
		code: anError errorCode
		debugger: (Debugger context: anError signalerContext)
		doitFlag: anError doitFlag.
	notifier category: anError category.
	SyntaxError open: notifier.