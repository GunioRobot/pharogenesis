rgbSub: sourceWord with: destinationWord
	self inline: false.
	destDepth < 16 ifTrue:
		["Sub each pixel separately"
		^ self partitionedSub: sourceWord from: destinationWord
						nBits: destDepth nPartitions: destPPW].
	destDepth = 16 ifTrue:
		["Sub RGB components of each pixel separately"
		^ (self partitionedSub: sourceWord from: destinationWord
						nBits: 5 nPartitions: 3)
		+ ((self partitionedSub: sourceWord>>16 from: destinationWord>>16
						nBits: 5 nPartitions: 3) << 16)]
	ifFalse:
		["Sub RGB components of the pixel separately"
		^ self partitionedSub: sourceWord from: destinationWord
						nBits: 8 nPartitions: 3]