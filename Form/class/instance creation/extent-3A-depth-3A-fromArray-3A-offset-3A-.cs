extent: extentPoint depth: bitsPerPixel fromArray: anArray offset: offsetPoint 
	"Answer an instance of me with a pixmap of the given depth initialized from anArray."

	^ (self basicNew setExtent: extentPoint depth: bitsPerPixel)
		offset: offsetPoint;
		initFromArray: anArray
