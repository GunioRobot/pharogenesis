tearOffTile
	(objectToView isKindOf: Player) ifTrue: [^ objectToView tearOffTileForSelf].

	objectToView ifNil: [^ nil].
	^ objectToView isMorph
		ifTrue:
			[objectToView]
		ifFalse:
			[objectToView costume]
