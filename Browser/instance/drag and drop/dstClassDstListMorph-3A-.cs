dstClassDstListMorph: dstListMorph
	| dropMorph |
	^(dstListMorph getListSelector == #classList)
		ifTrue: [(dropMorph _ dstListMorph potentialDropMorph) ifNotNil: [Smalltalk at: dropMorph contents withBlanksCondensed asSymbol]]
		ifFalse: [dstListMorph model selectedClass]