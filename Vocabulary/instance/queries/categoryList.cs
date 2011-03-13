categoryList
	"Answer the category list considering only code implemented in my 
	limitClass and lower. This variant is used when the limitClass and 
	targetObjct are known"
	| classToUse foundAMethod classThatImplements |
	classToUse := object class.
	^ categories
		select: [:aCategory | 
			foundAMethod := false.
			aCategory elementsInOrder
				do: [:aSpec | 
					classThatImplements := classToUse whichClassIncludesSelector: aSpec selector.
					(classThatImplements notNil
							and: [classThatImplements includesBehavior: limitClass])
						ifTrue: [foundAMethod := true]].
			foundAMethod]
		thenCollect: [:aCategory | aCategory categoryName]