testResetAfterEmphasized
	"self debug: #testResetAfterEmphasized"
	| normal derivative |
	normal _ TextStyle defaultFont.
	derivative _ normal emphasized: 3.
	self assert: (normal derivativeFonts at: 2) == derivative.
	normal reset.
	self assert: normal derivativeFonts isEmpty
