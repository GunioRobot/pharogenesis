createNextMap
	| maps mapName index |
	maps _ self availableMaps.
	mapName _ currentMap class.
	index _ maps indexOf: mapName.
	index < maps size
		ifTrue: [^ (maps at: index + 1) new]
		ifFalse: [^ nil]