dstCategoryDstListMorph: dstListMorph internal: internal 
	| dropMorph |
	^ internal & (dstListMorph getListSelector == #systemCategoryList)
		ifTrue: [(dropMorph _ dstListMorph potentialDropMorph) ifNotNil: [(self package , '-' , dropMorph contents) asSymbol]]
		ifFalse: [self selectedSystemCategoryName]