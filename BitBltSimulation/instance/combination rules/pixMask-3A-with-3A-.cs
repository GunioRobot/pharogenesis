pixMask: sourceWord with: destinationWord
	self inline: false.
	^ self partitionedAND: sourceWord bitInvert32 to: destinationWord
					nBits: destDepth nPartitions: destPPW