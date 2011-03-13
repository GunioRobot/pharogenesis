setBorderWidth: aWidth
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #borderWidth:) ifTrue: [^ renderedMorph borderWidth: aWidth].

	"If doing invisibly, do it equally to any hidden costume that cares"
	self costumesDo: [:aCostume | (aCostume renderedMorph respondsTo: #borderWidth) ifTrue: [aCostume renderedMorph borderWidth: aWidth]].

	"No instantiated costume bears a border width.  Very unlikely"
	^ (self costumeNamed: #RectangleMorph) borderWidth: aWidth