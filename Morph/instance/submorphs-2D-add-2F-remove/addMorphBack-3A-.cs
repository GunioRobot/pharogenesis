addMorphBack: aMorph

	aMorph owner ifNotNil: [aMorph owner privateRemoveMorph: aMorph].
	aMorph layoutChanged.
	aMorph privateOwner: self.
	submorphs _ submorphs copyWith: aMorph.
	aMorph changed.  "need to paint morphs now front, if any"
	self layoutChanged.
