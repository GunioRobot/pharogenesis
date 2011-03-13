categoryElementsFor: aCategorySymbol
	"Answer a list of tuples that characterize the elements in the given category.  Every class in the receiver's superclass chain which implements #additionsToViewerCategories is given the chance to add elements to the category"

	| aClass aList |
	aClass _ self renderedMorph class.
	aList _ OrderedCollection new.
	[aClass == Morph] whileFalse:
		[(aClass class includesSelector: #additionsToViewerCategories) ifTrue:
			[aList addAllFirst: (aClass additionsToViewerCategory: aCategorySymbol)].
		aClass _ aClass superclass]. 
	aList addAllFirst: (Morph additionsToViewerCategory: aCategorySymbol).
	^ aList
