assurePostscriptExists
	"Make sure there is a StringHolder holding the postscript.  "

	postscript == nil ifTrue: [postscript _ StringHolder new contents: '']