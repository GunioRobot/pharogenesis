tallyIntoMap: sourceWord with: destinationWord
	"Tally pixels into the color map.  Those tallied are exactly those
	in the destination rectangle.  Note that the source should be 
	specified == destination, in order for the proper color map checks 
	to be performed at setup."
	| mapIndex pixMask mask shiftWord |
	self inline: false.
	tallyMapSize = 0 ifTrue: [^ destinationWord "no op"].
	pixMask _ maskTable at: pixelDepth.
	shiftWord _ destinationWord.
	mask _ destMask.
	1 to: destPPW do:[:i |
		(mask bitAnd: pixMask) = 0 ifFalse:[
			mapIndex _ shiftWord bitAnd: pixMask.
			mapIndex _ self mapPixel: mapIndex.
			(mapIndex >= 0 and:[mapIndex < tallyMapSize]) ifTrue:[
				tallyMap at: mapIndex put: (tallyMap at: mapIndex) + 1]].
		mask _ mask >> pixelDepth.
		shiftWord _ shiftWord >> pixelDepth].
	^ destinationWord  "For no effect on dest"