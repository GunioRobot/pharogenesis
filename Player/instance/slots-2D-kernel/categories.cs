categories
	"Answer a list of categories appropriate to the the receiver and its costumes"

	| aList |
	(self hasCostumeThatIsAWorld)
		ifTrue:	[^ self categoriesForWorld].

	aList _ #('basic' ) asOrderedCollection.
	self slotNames size > 0 ifTrue:
		[aList add: 'instance variables'].
	self class scripts size > 0 ifTrue:
		[aList add: 'scripts'].

	aList addAll: #( 'color & border' 'tests' 'geometry' 'motion' 'pen use' 'miscellaneous' ).

	self costumesDo:
		[:aCostume | aCostume addCostumeSpecificCategoriesTo: aList].

	^ aList