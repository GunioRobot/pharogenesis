recategorizeMethodSelector: sel 
	"Categorize method named sel by looking in parent classes for a 
	method category. 
	Answer true if recategorized."
	| thisCat |
	self selectedClassOrMetaClass allSuperclasses
		do: [:ea | 
			thisCat := ea organization categoryOfElement: sel.
			(thisCat ~= ClassOrganizer default
					and: [thisCat notNil])
				ifTrue: [self classOrMetaClassOrganizer classify: sel under: thisCat.
					self changed: #messageCategoryList.
					^ true]].
	^ false