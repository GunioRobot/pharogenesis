authoringPrototype
	"Answer an instance of the receiver suitable for placing in a parts bin for authors"
	
	| book |
	book _ self new markAsPartsDonor.
	book removeEverything; pageSize: 128@102; color: (Color r: 0.9 g: 0.9 b: 0.9).
	book borderWidth: 1; borderColor: Color black.
	book addDressing; insertPage.
	^ book