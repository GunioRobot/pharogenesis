OLDtallyIntoMap: sourceWord with: destinationWord
	"Tally pixels into the tally map.  Note that the source should be 
	specified = destination, in order for the proper color map checks 
	to be performed at setup.
	Note that the region is not clipped to bit boundaries, but only to the
	nearest (enclosing) word.  This is because copyLoop does not do
	pre-merge masking.  For accurate results, you must subtract the
	values obtained from the left and right fringes."
	| mapIndex pixMask shiftWord |
	tallyMapSize = 0 ifTrue: [^ destinationWord "no op"].
	"loop through all packed pixels."
	pixMask _ maskTable at: pixelDepth.
	shiftWord _ destinationWord.
	1 to: destPPW do:[:i |
		mapIndex _ shiftWord bitAnd: pixMask.
		mapIndex _ self mapPixel: mapIndex.
		(mapIndex >= 0 and:[mapIndex < tallyMapSize]) ifTrue:[
			tallyMap at: mapIndex put: (tallyMap at: mapIndex) + 1.
		].
		shiftWord _ shiftWord >> pixelDepth].
	^ destinationWord