setExtent: extent offset: aPoint
	"Create a virtual bit map with the givcen extent and offset."

	^ (self setExtent: extent depth: 1) offset: aPoint