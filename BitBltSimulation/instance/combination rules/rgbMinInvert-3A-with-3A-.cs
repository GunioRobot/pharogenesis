rgbMinInvert: wordToInvert with: destinationWord
	| sourceWord |
	self inline: false.
	sourceWord _ wordToInvert bitInvert32.
	destPixSize < 16 ifTrue:
		["Min each pixel separately"
		^ self partitionedMin: sourceWord with: destinationWord
						nBits: destPixSize nPartitions: pixPerWord].
	destPixSize = 16 ifTrue:
		["Min RGB components of each pixel separately"
		^ (self partitionedMin: sourceWord with: destinationWord
						nBits: 5 nPartitions: 3)
		+ ((self partitionedMin: sourceWord>>16 with: destinationWord>>16
						nBits: 5 nPartitions: 3) << 16)]
	ifFalse:
		["Min RGB components of the pixel separately"
		^ self partitionedMin: sourceWord with: destinationWord
						nBits: 8 nPartitions: 3]