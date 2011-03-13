toggleSnapshotBackground
	(self hasProperty: #backgroundSnapshot)
		ifTrue:[self removeProperty: #backgroundSnapshot]
		ifFalse:[self setProperty: #backgroundSnapshot toValue: (Form extent: 1@1)].