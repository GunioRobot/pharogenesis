categories
	"Answer a list of categories appropriate to the the receiver and its costumes"

	| aList |
	(self hasCostumeThatIsAWorld)
		ifTrue:	[^ self categoriesForWorld].

	aList _ OrderedCollection new.
	self slotNames size > 0 ifTrue:
		[aList add: #'instance variables'].
	aList addAll: costume categoriesForViewer.
	aList add: #scripts after: aList first.
	^ aList