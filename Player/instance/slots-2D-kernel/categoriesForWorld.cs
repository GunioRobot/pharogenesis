categoriesForWorld
	"Answer the list of categories given that the receiver is the Player representing a World"

	| aList |
	aList _ #(#'color & border' #'pen trails' playfield) asOrderedCollection.
	self class scripts size > 0 ifTrue:
		[aList addFirst: #scripts].
	self slotNames size > 0 ifTrue:
		[aList addFirst: #'instance variables'].

	^ aList