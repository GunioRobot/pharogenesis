authoringPrototype
	"Answer an instance of the receiver suitable for placing in a parts bin for authors"
	
	| book |
	book _ self new markAsPartsDonor.
	book removeEverything; pageSize: 360@228; color: (Color gray: 0.9).
	book borderWidth: 1; borderColor: Color black.
	book beSticky.
	book showPageControls; insertPage.
	^ book