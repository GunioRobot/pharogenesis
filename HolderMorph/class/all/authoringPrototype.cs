authoringPrototype
	"Answer an instance of the receiver suitable for placing in a parts bin for authors"
	
	| proto |
	proto _ self new markAsPartsDonor.
	proto extent: 100@80; color: (Color r: 1.0 g: 0.9 b: 0.7).
	^ proto