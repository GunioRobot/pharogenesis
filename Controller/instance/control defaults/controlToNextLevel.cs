controlToNextLevel
	"Pass control to the next control level (that is, to the Controller of a 
	subView of the receiver's view) if possible. The receiver finds the 
	subView (if any) of its view whose inset display box (see 
	View|insetDisplayBox) contains the sensor's cursor point. The Controller 
	of this subView is then given control if it answers true in response to 
	the message Controller|isControlWanted."

	| aView |
	aView _ view subViewWantingControl.
	aView ~~ nil ifTrue: [aView controller startUp]