noteSignificantEvent: newEvent
	"Force a repeated event to be handled with significance, assuming it got
	dropped by the repetition filter in normal handleEvent:.
	Useful for, eg, repeat-button held down"

	newEvent = lastEvent ifTrue: [self handleSignificantEvent: newEvent]