tallyIntoMap: sourceWord with: destinationWord
	"Tally pixels into the color map.  Those tallied are exactly those
	in the destination rectangle.  Note that the source should be 
	specified == destination, in order for the proper color map checks 
	to be performed at setup."
	| mapIndex pixMask destShifted maskShifted pixVal |
	self inline: false.
	colorMap = nil
		ifTrue: [^ destinationWord "no op"].
	pixMask _ maskTable at: destPixSize.
	destShifted _ destinationWord.
	maskShifted _ destMask.
	1 to: pixPerWord do:
		[:i |
		(maskShifted bitAnd: pixMask) = 0 ifFalse:
			["Only tally pixels within the destination rectangle"
			pixVal _ destShifted bitAnd: pixMask.
			destPixSize < 16
				ifTrue: [mapIndex _ pixVal]
				ifFalse: [destPixSize = 16
					ifTrue: [mapIndex _ self rgbMap: pixVal from: 5 to: cmBitsPerColor]
					ifFalse: [mapIndex _ self rgbMap: pixVal from: 8 to: cmBitsPerColor]].
			self colormapAt: mapIndex put: (self colormapAt: mapIndex) + 1].
		maskShifted _ maskShifted >> destPixSize.
		destShifted _ destShifted >> destPixSize].
	^ destinationWord  "For no effect on dest"