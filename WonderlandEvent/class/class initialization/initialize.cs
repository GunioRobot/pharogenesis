initialize
	"Add some new constants to the WonderlandConstants shared pool"

	| dict |
	dict _ Smalltalk at: #WonderlandConstants.
	#(leftMouseDown leftMouseUp rightMouseDown rightMouseUp leftMouseClick rightMouseClick mouseMove keyPress) do:[:each| 
		dict declare: each from: Undeclared.
		dict at: each put: each.
	].