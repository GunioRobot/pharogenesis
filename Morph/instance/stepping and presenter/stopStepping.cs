stopStepping
	"Stop getting sent the 'step' message."

	| w |
	w _ self world.
	w ifNotNil: [w stopStepping: self].
