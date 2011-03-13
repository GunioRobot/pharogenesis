someColor: colorIndex
	"Map 0 to white, 1 to black, and 2...nColors throughout the 
	remaining color space for this pixel depth"

	^ (Color allColorsForDepth: depth) atWrap: colorIndex