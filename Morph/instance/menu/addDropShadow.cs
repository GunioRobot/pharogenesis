addDropShadow
	| ds |
	self owner addMorph: (ds _ DropShadowMorph new).
	ds addMorph: self