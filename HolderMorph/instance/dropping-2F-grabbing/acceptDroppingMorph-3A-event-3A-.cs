acceptDroppingMorph: aMorph event: evt
	aMorph submorphsDo: [:m | (m isKindOf: HaloMorph) ifTrue: [m delete]].
	self privateAddMorph: aMorph atIndex: (self insertionIndexFor: aMorph).
	self changed.
	self layoutChanged.
