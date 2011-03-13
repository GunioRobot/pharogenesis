decideToSkipAFrame: delta averageWait: aWaitTime stream: aStream
	| estimatedFrames |

	delta abs > aWaitTime ifTrue: 
		[estimatedFrames := ( delta abs / (1000 / self frameRate)) asInteger.
		self videoDropFrames:  estimatedFrames stream: aStream].