morphicKeyPress: event
	"Handle the given event"
	| evt |
	myTexture isMorph ifTrue:[
		evt _ event getMorphicEvent copy.
		evt setCursorPoint: (myTexture mapPrimitiveVertex: event getVertex).
		myTexture keyStroke: evt].