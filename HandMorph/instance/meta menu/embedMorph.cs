embedMorph 
	| rootMorphs morphToEmbed targetRoot targetMorph worldPosition |
	rootMorphs _ self world rootMorphsAt: menuTargetOffset.
	rootMorphs size < 2 ifTrue: [^ self].
	morphToEmbed _ rootMorphs at: 1.
	worldPosition _ morphToEmbed position.
	targetRoot _ rootMorphs at: 2.
	targetMorph _ self chooseTargetSubmorphOf: targetRoot caption: 'Embed in...'.
	targetMorph ifNotNil: [
		targetMorph addMorphBack: morphToEmbed
				fromWorldPosition: worldPosition].
