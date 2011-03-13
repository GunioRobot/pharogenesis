applyColorMap
	"Convert theForm to the best approximation of the colors in colorMap.  Then make the map be nil.  Informaion will be lost.  Converts the arbitrary 256 colors in the picture (via the map) to the standard 256 colors.  When colorMaps are fully supported, stop using this.  7/1/96 tk"

	| port |
	port _ BitBlt toForm: theForm.
	port colorMap: self rawColorMap.
	theForm displayOnPort: port at: 0@0.
		"Write over self using the transforming color map"
	colorMap _ nil.