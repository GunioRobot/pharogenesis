privateAddMorph: aMorph atIndex: index

	((index >= 1) and: [index <= (submorphs size + 1)])
		ifFalse: [^ self error: 'index out of range'].
	aMorph owner ifNotNil: [aMorph owner privateRemoveMorph: aMorph].
	aMorph layoutChanged.
	aMorph privateOwner: self.
	submorphs _ submorphs copyReplaceFrom: index to: index-1 with: (Array with: aMorph).
	self layoutChanged.
