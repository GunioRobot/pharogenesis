isPlaying
	^((self audioPlayerProcess isNil) and: [self videoPlayerProcess isNil]) not