pushIntegerResultExpr: valueExpr
	"Return an expression to push an integer valued result."

	| conversionExpr |
	conversionExpr _
		TSendNode new
			setSelector: #pushInteger:
			receiver: #self
			arguments: valueExpr.
	^ TSendNode new
		setSelector: #push:
		receiver: #self
		arguments: conversionExpr
