install

	submorphs do: [:ss | ss owner == nil ifTrue: [ss privateOwner: self]].
		"Transcript that was in outPointers and then got deleted."
	self viewBox: Display boundingBox.
	self handsDo: [:h | h initForEvents].

	self installFlaps.

	SystemWindow noteTopWindowIn: self.
	self displayWorldSafely.
