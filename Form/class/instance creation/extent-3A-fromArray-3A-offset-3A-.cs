extent: extentPoint fromArray: anArray offset: offsetPoint 
	"Answer an instance of me with bitmap initialized from anArray."

	^ (self basicNew setExtent: extentPoint offset: offsetPoint)
		initFromArray: anArray