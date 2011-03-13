getBorderWidth
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #borderWidth) ifTrue: [^ renderedMorph borderWidth].
	self costumesDo: [:aCostume | (aCostume respondsTo: #borderWidth) ifTrue: [^ aCostume borderWidth]].
	"No instantiated costume bears a border width.  Very unlikely"
	^ (self costumeNamed: #RectangleMorph) borderWidth