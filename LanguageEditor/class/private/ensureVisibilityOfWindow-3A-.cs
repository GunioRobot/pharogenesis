ensureVisibilityOfWindow: aWindow 
	"private - activate the window"
	| |
	aWindow expand.
	aWindow comeToFront.
	""
	aWindow
		right: (aWindow right min: World right).
	aWindow
		bottom: (aWindow bottom min: World bottom).
	aWindow
		left: (aWindow left max: World left).
	aWindow
		top: (aWindow top max: World top).
	""
	aWindow flash; flash