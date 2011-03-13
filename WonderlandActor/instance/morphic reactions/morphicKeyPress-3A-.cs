morphicKeyPress: event
	"Handle the given event"
	myTexture isMorph ifTrue:[self dispatchEvent: event to: myTexture].