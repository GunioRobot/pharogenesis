activateWindow: aWindow 
	"private - activate the window"
	aWindow
		right: (aWindow right min: World bounds right).
	aWindow
		bottom: (aWindow bottom min: World bounds bottom).
	aWindow
		left: (aWindow left max: World bounds left).
	aWindow
		top: (aWindow top max: World bounds top).
	""
	aWindow comeToFront.
	aWindow flash