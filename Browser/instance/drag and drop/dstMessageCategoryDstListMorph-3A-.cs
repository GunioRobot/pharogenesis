dstMessageCategoryDstListMorph: dstListMorph
	| dropItem |
	^dstListMorph getListSelector == #messageCategoryList
		ifTrue: 
			[dropItem _ dstListMorph potentialDropItem.
			dropItem ifNotNil: [dropItem asSymbol]]
		ifFalse: [self selectedMessageCategoryName ifNil: [ Categorizer default ]]