addMorphFront: aMorph

	| newSubmorphs |
	aMorph owner ifNotNil: [aMorph owner privateRemoveMorph: aMorph].
	aMorph layoutChanged.
	aMorph privateOwner: self.
	newSubmorphs _ submorphs species new: submorphs size + 1.
	newSubmorphs at: 1 put: aMorph.
	newSubmorphs
		replaceFrom: 2
		to: newSubmorphs size
		with: submorphs
		startingAt: 1.
	submorphs _ newSubmorphs.
	aMorph changed.
	self layoutChanged.
