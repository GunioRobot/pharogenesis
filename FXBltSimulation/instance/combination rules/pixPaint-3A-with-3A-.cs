pixPaint: sourceWord with: destinationWord
	self inline: false.
	sourceWord = 0 ifTrue: [^ destinationWord].
	^ sourceWord bitOr:
		(self partitionedAND: sourceWord bitInvert32 to: destinationWord
						nBits: destDepth nPartitions: destPPW)