addSoundTrack
	| fileName |
	fileName := Utilities chooseFileWithSuffixFromList: #('.aif' '.wav')
				withCaption: 'Choose a sound track file'.
	fileName isNil ifTrue: [^self].
	soundTrackFileName := fileName.
	self tryToShareScoreFor: soundTrackFileName.
	scorePlayer ifNil: 
			[('*aif' match: fileName) 
				ifTrue: [scorePlayer := SampledSound fromAIFFfileNamed: fileName].
			('*wav' match: fileName) 
				ifTrue: [scorePlayer := SampledSound fromWaveFileNamed: fileName]].
	soundTrackForm ifNotNil: 
			["Compute new soundTrack if we're showing it."

			self
				showHideSoundTrack;
				showHideSoundTrack]