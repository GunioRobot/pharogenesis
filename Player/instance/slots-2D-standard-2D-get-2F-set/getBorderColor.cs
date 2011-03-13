getBorderColor
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #borderColor) ifTrue: [^ renderedMorph borderColor].

	self costumesDo: [:aCostume | (aCostume respondsTo: #borderColor) ifTrue: [^ aCostume borderColor]].
	"No instantiated costume bears a border color.  Very unlikely"
	^ (self costumeNamed: #RectangleMorph) borderColor