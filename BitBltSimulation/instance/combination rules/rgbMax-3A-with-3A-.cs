rgbMax: sourceWord with: destinationWord
	self inline: false.
	destPixSize < 16 ifTrue:
		["Max each pixel separately"
		^ self partitionedMax: sourceWord with: destinationWord
						nBits: destPixSize nPartitions: pixPerWord].
	destPixSize = 16 ifTrue:
		["Max RGB components of each pixel separately"
		^ (self partitionedMax: sourceWord with: destinationWord
						nBits: 5 nPartitions: 3)
		+ ((self partitionedMax: sourceWord>>16 with: destinationWord>>16
						nBits: 5 nPartitions: 3) << 16)]
	ifFalse:
		["Max RGB components of the pixel separately"
		^ self partitionedMax: sourceWord with: destinationWord
						nBits: 8 nPartitions: 3]