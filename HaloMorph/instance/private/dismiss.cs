dismiss
	"Remove my target from the world."

	| w |
	self isThisEverCalled. "Seemingly no longer enfranchised"
	w _ self world.
	w ifNotNil: [w stopStepping: target].
	self delete.
	target dismissViaHalo