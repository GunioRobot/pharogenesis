OLDtallyIntoMap: sourceWord with: destinationWord
	"Tally pixels into the color map.  Note that the source should be 
	specified = destination, in order for the proper color map checks 
	to be performed at setup.
	Note that the region is not clipped to bit boundaries, but only to the
	nearest (enclosing) word.  This is because copyLoop does not do
	pre-merge masking.  For accurate results, you must subtract the
	values obtained from the left and right fringes."
	| mapIndex pixMask shiftWord |
	colorMap = nil
		ifTrue: [^ destinationWord "no op"].
	destPixSize < 16 ifTrue:
		["loop through all packed pixels."
		pixMask _ maskTable at: destPixSize.
		shiftWord _ destinationWord.
		1 to: pixPerWord do:
			[:i |
			mapIndex _ shiftWord bitAnd: pixMask.
			self colormapAt: mapIndex put: (self colormapAt: mapIndex) + 1.
			shiftWord _ shiftWord >> destPixSize].
		^ destinationWord].
	destPixSize = 16 ifTrue:
		["Two pixels  Tally the right half..."
		mapIndex _ self rgbMap: (destinationWord bitAnd: 16rFFFF) from: 5 to: cmBitsPerColor.
		self colormapAt: mapIndex put: (self colormapAt: mapIndex) + 1.
		"... and then left half"
		mapIndex _ self rgbMap: destinationWord>>16 from: 5 to: cmBitsPerColor.
		self colormapAt: mapIndex put: (self colormapAt: mapIndex) + 1]
	ifFalse:
		["Just one pixel."
		mapIndex _ self rgbMap: destinationWord from: 8 to: cmBitsPerColor.
		self colormapAt: mapIndex put: (self colormapAt: mapIndex) + 1].
	^ destinationWord  "For no effect on dest"