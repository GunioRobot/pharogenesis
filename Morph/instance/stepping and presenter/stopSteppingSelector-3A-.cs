stopSteppingSelector: aSelector
	"Stop getting sent the given message."
	| w |
	w _ self world.
	w ifNotNil: [w stopStepping: self selector: aSelector].
