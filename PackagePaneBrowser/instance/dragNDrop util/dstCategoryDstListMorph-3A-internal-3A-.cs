dstCategoryDstListMorph: dstListMorph internal: internal 
	| dropItem |
	^ internal & (dstListMorph getListSelector == #systemCategoryList)
		ifTrue: [(dropItem _ dstListMorph potentialDropItem) ifNotNil: [(self package , '-' , dropItem) asSymbol]]
		ifFalse: [self selectedSystemCategoryName]