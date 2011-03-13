dismiss
	"Remove my target from the world."

	| w |
	w _ self world.
	w ifNotNil: [w stopStepping: target].
	self delete.
	target delete.
