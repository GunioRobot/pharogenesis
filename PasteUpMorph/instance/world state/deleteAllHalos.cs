deleteAllHalos
	self haloMorphs do:
		[:m | (m target isKindOf: SelectionMorph) ifTrue: [m target delete].
		m delete].
