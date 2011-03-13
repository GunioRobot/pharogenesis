setBorderColor: aColor
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #borderColor:) ifTrue: [^ renderedMorph borderColor: aColor].

	"If doing invisibly, do it equally to any hidden costume that cares"
	self costumesDo: [:aCostume | ((renderedMorph _ aCostume renderedMorph) respondsTo: #borderColor:) ifTrue: [renderedMorph borderColor: aColor]].

	"No instantiated costume bears a border color.  Very unlikely"
	^ (self costumeNamed: #RectangleMorph) borderColor: aColor