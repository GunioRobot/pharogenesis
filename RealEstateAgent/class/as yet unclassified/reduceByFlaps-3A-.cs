reduceByFlaps: aScreenRect 
	"Return a rectangle that won't interfere with default shared flaps"

	Flaps sharedFlapsAllowed ifFalse: [^ aScreenRect copy].
	(Flaps globalFlapTabsIfAny allSatisfy:
			[:ft | ft flapID = 'Painting' translated or: [ft edgeToAdhereTo == #bottom]])
		ifTrue: [^ aScreenRect withHeight: aScreenRect height - 18]
		ifFalse: [^ aScreenRect insetBy: 18]