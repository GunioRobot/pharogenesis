addPalettes
	paintPalette _ PaintBoxMorph newSticky.
	controlsPalette _ self controlsBook.
	suppliesPalette _ self suppliesBook.
	"Later share the userStuff across EToys?  Not now."
	userStuffPalette ifNil: [
		userStuffPalette _ EToyHolder userStuffBook fullCopy beSticky].
