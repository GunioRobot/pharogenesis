keyStroke: event 
	"Process spacebar for action and tab keys for navigation."
	
	(self navigationKey: event) ifTrue: [^self].
	event keyCharacter = Character space
		ifTrue: [self performAction]