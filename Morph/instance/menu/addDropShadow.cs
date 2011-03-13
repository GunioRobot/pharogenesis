addDropShadow
	| ds hadHalo |
	(hadHalo _ self hasHalo) ifTrue: [self halo delete].
	self owner addMorph: (ds _ DropShadowMorph new).
	ds addMorph: self.
	hadHalo ifTrue: [ds addHalo]