resetFrom: scorePlayer 
	(movieClipPlayer cueMorph isNil 
		or: [self startTime < movieClipPlayer cueMorph startTime]) 
			ifTrue: 
				[movieClipPlayer
					openFileNamed: movieClipFileName
						withScorePlayer: soundTrackPlayerReady copy
						andPlayFrom: frameNumber;
					setCueMorph: self;
					step;
					pauseFrom: scorePlayer]