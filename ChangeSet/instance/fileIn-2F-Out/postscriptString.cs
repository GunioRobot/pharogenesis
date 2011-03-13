postscriptString
	"Answer the string representing the postscript.  "

	^ postscript == nil
		ifTrue:
			[postscript]
		ifFalse:
			[postscript contents asString]