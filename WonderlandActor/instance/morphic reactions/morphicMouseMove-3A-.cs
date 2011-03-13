morphicMouseMove: event
	"Handle the given event"
	(event getMorphicEvent shiftPressed and:[self getUserPointOfView notNil])
		ifTrue:[^self]. "Reserved for navigation"
	(self getProperty: #userTransition) == true ifTrue:[^true]. "Shift key went up"
	myTexture isMorph ifTrue:[
		self dispatchEvent: event to: myTexture.
	].