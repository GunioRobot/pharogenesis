install

	owner _ nil.	"since we may have been inside another world previously"

	submorphs do: [:ss | ss owner == nil ifTrue: [ss privateOwner: self]].
		"Transcript that was in outPointers and then got deleted."
	self viewBox: Display boundingBox.
	Sensor eventQueue: SharedQueue new.
	worldState handsDo: [:h | h initForEvents].

	self installFlaps.

	SystemWindow noteTopWindowIn: self.
	self displayWorldSafely.
