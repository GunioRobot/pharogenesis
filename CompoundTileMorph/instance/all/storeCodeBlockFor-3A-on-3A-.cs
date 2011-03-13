storeCodeBlockFor: scriptPart on: aStream

	| lastTile |
	lastTile _ nil.
	scriptPart allMorphsDo: [:m |
		(m isKindOf: TileMorph) ifTrue: [
			(self tile: m isOnLineAfter: lastTile) ifTrue: [
				lastTile ~~ nil ifTrue: [aStream nextPut: $.; cr].
				aStream tab; tab.
			] ifFalse: [
				(lastTile ~= nil) ifTrue: [aStream space]].
			m storeCodeOn: aStream.
			lastTile _ m]].
