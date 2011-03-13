playNextAudioMessage

	(self newAudioMessages nextOrNil ifNil: [^self]) asSound play.