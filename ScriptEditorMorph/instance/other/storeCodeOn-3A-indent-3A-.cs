storeCodeOn: aStream indent: tabCount

	| lastOwner |
	lastOwner _ nil.
	self tileRows do: [:r |
		r do: [:m |
			((m isKindOf: TileMorph) or:
			 [(m isKindOf: CompoundTileMorph) or:
			 [m isKindOf: PhraseTileMorph]]) ifTrue: [
				tabCount timesRepeat: [aStream tab].
				((m owner ~= lastOwner) and: [lastOwner ~= nil])
					ifTrue:
						[aStream nextPut: $.; cr; tab.
						m storeCodeOn: aStream indent: tabCount]
					ifFalse:
						[(lastOwner ~= nil) ifTrue: [aStream space].
						m storeCodeOn: aStream indent: tabCount].
				lastOwner _ m owner]]].
