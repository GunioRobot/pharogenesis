morphicMouseUp: event
	"Handle the given event"
	(event getMorphicEvent shiftPressed and:[self getUserPointOfView notNil])
		ifTrue:[^self]. "Reserved for navigation"
	(self getProperty: #userTransition) == true ifTrue:["Shift key went up"
		^self setProperty: #userTransition toValue: nil].
	myTexture isMorph ifTrue:[
		self dispatchEvent: event using:[:evt :hand| hand handleMouseUp: evt].
	].