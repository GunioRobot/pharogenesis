handleEvent: newEvent
	"Ignores repeated events such as unmoving mouse"

	newEvent = lastEvent ifTrue: [^ self].
	self handleSignificantEvent: newEvent