categoryList
	"Answer the category list considering only code implemented in my 
	limitClass and lower. This variant is used when the limitClass and 
	targetObjct are known"
	| classToUse foundAMethod classThatImplements |
	classToUse _ object class.
	^ categories
		select: [:aCategory | 
			foundAMethod _ false.
			aCategory elementsInOrder
				do: [:aSpec | 
					classThatImplements _ classToUse whichClassIncludesSelector: aSpec selector.
					(classThatImplements notNil
							and: [classThatImplements includesBehavior: limitClass])
						ifTrue: [foundAMethod _ true]].
			foundAMethod]
		thenCollect: [:aCategory | aCategory categoryName]