categoriesForWorld
	"Answer the list of categories given that the receiver is the Player representing a World"
	| aList |
	aList _ #('basic' 'color & border' 'pen trails' 'playfield') asOrderedCollection.
	self slotNames size > 0 ifTrue:
		[aList add: 'instance variables'].
	self class scripts size > 0 ifTrue:
		[aList add: 'scripts'].

	aList removeAllFoundIn: #('card/stack commands' 'object fileIn').

	^ aList