authoringPrototype
	"Answer an instance of the receiver suitable for placing in a parts bin for authors"
	
	| book |
	book _ self new markAsPartsDonor.
	book removeEverything; pageSize: 100@120; color: (Color r: 1.0 g: 0.9 b: 1.0).
	book addDressing; insertPage.
	^ book