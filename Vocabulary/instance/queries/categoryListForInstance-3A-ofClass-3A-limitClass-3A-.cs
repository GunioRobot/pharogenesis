categoryListForInstance: targetObject ofClass: aClass limitClass: mostGenericClass 
	"Answer the category list for the given instance (may be nil) of the 
	given class, considering only code implemented in mostGenericClass and 
	lower "
	| classToUse foundAMethod classThatImplements |
	classToUse _ targetObject
				ifNil: [aClass]
				ifNotNil: [targetObject class].
	^ categories
		select: [:aCategory | 
			foundAMethod _ false.
			aCategory elementsInOrder
				do: [:aSpec | 
					classThatImplements _ classToUse whichClassIncludesSelector: aSpec selector.
					(classThatImplements notNil
							and: [classThatImplements includesBehavior: mostGenericClass])
						ifTrue: [foundAMethod _ true]].
			foundAMethod]
		thenCollect: [:aCategory | aCategory categoryName]