embedMorph 
	| rootMorphs morphToEmbed targetRoot targetMorph worldPosition |
	self flag: #noteToJohn.  "The original Morphic implementation.  This is theoretically supplanted by #placeArgumentIn, but is retained here, unsent, for the time being"

	rootMorphs _ self world rootMorphsAt: targetOffset.
	rootMorphs size < 2 ifTrue: [^ self].
	morphToEmbed _ rootMorphs at: 1.
	worldPosition _ morphToEmbed position.
	targetRoot _ rootMorphs at: 2.
	targetMorph _ self chooseTargetSubmorphOf: targetRoot caption: 'Embed in...'.
	targetMorph ifNotNil:
		[targetMorph addMorphFront: morphToEmbed
				fromWorldPosition: worldPosition].
