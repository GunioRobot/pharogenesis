dstCategoryDstListMorph: dstListMorph
	| dropMorph |
	^(dstListMorph getListSelector == #systemCategoryList)
		ifTrue: [(dropMorph _ dstListMorph potentialDropMorph) ifNotNil: [dropMorph contents]]
		ifFalse: [self selectedSystemCategoryName]