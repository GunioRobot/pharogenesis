addMorphFront: aMorph

	aMorph owner ifNotNil: [aMorph owner privateRemoveMorph: aMorph].
	aMorph layoutChanged.
	aMorph privateOwner: self.
	submorphs _ (Array with: aMorph), submorphs.
	aMorph changed.
	self layoutChanged.
