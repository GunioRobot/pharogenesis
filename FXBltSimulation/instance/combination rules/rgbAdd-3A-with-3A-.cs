rgbAdd: sourceWord with: destinationWord
	self inline: false.
	pixelDepth < 16 ifTrue:
		["Add each pixel separately"
		^ self partitionedAdd: sourceWord to: destinationWord
						nBits: pixelDepth nPartitions: destPPW].
	pixelDepth = 16 ifTrue:
		["Add RGB components of each pixel separately"
		^ (self partitionedAdd: sourceWord to: destinationWord
						nBits: 5 nPartitions: 3)
		+ ((self partitionedAdd: sourceWord>>16 to: destinationWord>>16
						nBits: 5 nPartitions: 3) << 16)]
	ifFalse:
		["Add RGB components of the pixel separately"
		^ self partitionedAdd: sourceWord to: destinationWord
						nBits: 8 nPartitions: 3]