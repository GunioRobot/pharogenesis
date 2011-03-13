open: anObject label: aString
	"Build an open the object, labeling it appropriately.  Answer the widget opened."
	| window |
	window := self open: anObject.
	window setLabel: aString.
	^window