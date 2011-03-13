open: anObject
	"Build and open the object. Answer the widget opened."
	| window |
	window := self build: anObject.
	window controller open.
	^window