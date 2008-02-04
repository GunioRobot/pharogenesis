testResetAfterEmphasized
	"self debug: #testResetAfterEmphasized"
	| normal derivative |
	normal := TextStyle defaultFont.
	derivative := normal emphasized: 3.
	self assert: (normal derivativeFonts at: 3) == derivative.
	normal reset.
	self assert: normal derivativeFonts isEmpty
