decideToSkipAFrame: delta averageWait: aWaitTime stream: aStream
	| estimatedFrames |

	delta abs > aWaitTime ifTrue: 
		[estimatedFrames _ ( delta abs / (1000 / self frameRate)) asInteger.
		self videoDropFrames:  estimatedFrames stream: aStream].