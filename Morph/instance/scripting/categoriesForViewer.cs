categoriesForViewer
	"Answer a list of symbols representing the categories to offer in the viewer, in order"

	| aClass aList predetermined genericItems |
	aClass _ self renderedMorph class.
	aList _ OrderedCollection new.
	[aClass == Morph] whileFalse:
		[(aClass class includesSelector: #additionsToViewerCategories) ifTrue:
			[aList addAllFirst: (aClass additionsToViewerCategories collect:
				[:categorySpec | categorySpec first])].
		aClass _ aClass superclass]. 

	genericItems _ Morph additionsToViewerCategories collect:
			[:categorySpec | categorySpec first].
	aList removeAllFoundIn: genericItems.

	aList addAllFirst: (Morph additionsToViewerCategories collect:
			[:categorySpec | categorySpec first]) asSet asOrderedCollection.
	predetermined _ #(basic #'color & border' geometry motion #'pen use' tests miscellaneous) select:
		[:sym | aList includes: sym].  "bulletproof agains change in those names elsewhere"
	aList removeAllFoundIn: predetermined.
	^ predetermined, aList
