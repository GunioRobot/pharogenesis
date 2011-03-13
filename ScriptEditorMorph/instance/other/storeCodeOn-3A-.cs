storeCodeOn: aStream

	| lastOwner |
	lastOwner _ nil.
	self tileRows do: [:r |
		r do: [:m |
			((m isKindOf: TileMorph) or: [(m isKindOf: CompoundTileMorph) or: [m isKindOf: PhraseTileMorph]])
				ifTrue:
					[((m owner ~= lastOwner) and: [lastOwner ~= nil])
						ifTrue:
							[aStream nextPut: $.; cr; tab.
							m storeCodeOn: aStream]
						ifFalse:
							[(lastOwner ~= nil) ifTrue: [aStream space].
							m storeCodeOn: aStream].
					lastOwner _ m owner]]]