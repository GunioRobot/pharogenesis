addAllMorphs: aCollection after: anotherMorph

	| index |
	index _ submorphs indexOf: anotherMorph ifAbsent: [submorphs size].
	aCollection do: [:m |
		m owner ifNotNil: [m owner privateRemoveMorph: m].
		m layoutChanged.
		m privateOwner: self].
	submorphs _ (submorphs copyFrom: 1 to: index), aCollection,
			(submorphs copyFrom: index+1 to: submorphs size).
	self layoutChanged.
