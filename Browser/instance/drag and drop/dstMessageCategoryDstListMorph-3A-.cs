dstMessageCategoryDstListMorph: dstListMorph
	| dropMorph |
	^dstListMorph getListSelector == #messageCategoryList
		ifTrue: 
			[dropMorph _ dstListMorph potentialDropMorph.
			dropMorph ifNotNil: [dropMorph contents asSymbol]]
		ifFalse: [self selectedMessageCategoryName]