dstClassDstListMorph: dstListMorph
	| dropItem |
	^(dstListMorph getListSelector == #classList)
		ifTrue: [(dropItem _ dstListMorph potentialDropItem) ifNotNil: [Smalltalk at: dropItem withBlanksCondensed asSymbol]]
		ifFalse: [dstListMorph model selectedClass]