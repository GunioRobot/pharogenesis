tallyIntoMap: sourceWord with: destinationWord
	"Tally pixels into the color map.  Those tallied are exactly those
	in the destination rectangle.  Note that the source should be 
	specified == destination, in order for the proper color map checks 
	to be performed at setup."
	| mapIndex pixMask destShifted maskShifted pixVal |
	self inline: false.
	(cmFlags bitAnd: (ColorMapPresent bitOr: ColorMapIndexedPart)) = 
		(ColorMapPresent bitOr: ColorMapIndexedPart)
			ifFalse: [^ destinationWord "no op"].
	pixMask _ maskTable at: destDepth.
	destShifted _ destinationWord.
	maskShifted _ destMask.
	1 to: destPPW do:
		[:i |
		(maskShifted bitAnd: pixMask) = 0 ifFalse:
			["Only tally pixels within the destination rectangle"
			pixVal _ destShifted bitAnd: pixMask.
			destDepth < 16
				ifTrue: [mapIndex _ pixVal]
				ifFalse: [destDepth = 16
					ifTrue: [mapIndex _ self rgbMap: pixVal from: 5 to: cmBitsPerColor]
					ifFalse: [mapIndex _ self rgbMap: pixVal from: 8 to: cmBitsPerColor]].
			self tallyMapAt: mapIndex put: (self tallyMapAt: mapIndex) + 1].
		maskShifted _ maskShifted >> destDepth.
		destShifted _ destShifted >> destDepth].
	^ destinationWord  "For no effect on dest"