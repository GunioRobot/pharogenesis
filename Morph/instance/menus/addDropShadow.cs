addDropShadow
	| ds hadHalo |
	(hadHalo _ self hasHalo) ifTrue: [self halo delete].
	self owner replaceSubmorph: self by: (ds _ DropShadowMorph new).
	ds addMorph: self.
	self transferStateToRenderer: ds.
	hadHalo ifTrue: [ds addHalo]