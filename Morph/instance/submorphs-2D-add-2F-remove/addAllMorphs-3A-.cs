addAllMorphs: aCollection

	aCollection do: [:m |
		m owner ifNotNil: [m owner privateRemoveMorph: m].
		m layoutChanged.
		m privateOwner: self].
	submorphs _ submorphs, aCollection.
	self layoutChanged.
