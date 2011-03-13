categoryListForInstance: targetObject ofClass: aClass limitClass: mostGenericClass 
	"Answer the category list for the given instance (may be nil) of the 
	given class, considering only code implemented in mostGenericClass and 
	lower "
	| classToUse foundAMethod classThatImplements |
	classToUse := targetObject
				ifNil: [aClass]
				ifNotNil: [targetObject class].
	^ categories
		select: [:aCategory | 
			foundAMethod := false.
			aCategory elementsInOrder
				do: [:aSpec | 
					classThatImplements := classToUse whichClassIncludesSelector: aSpec selector.
					(classThatImplements notNil
							and: [classThatImplements includesBehavior: mostGenericClass])
						ifTrue: [foundAMethod := true]].
			foundAMethod]
		thenCollect: [:aCategory | aCategory categoryName]