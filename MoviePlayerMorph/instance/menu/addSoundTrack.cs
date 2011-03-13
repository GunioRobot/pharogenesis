addSoundTrack

	| fileName |
	fileName _ Utilities chooseFileWithSuffixFromList: #('.aif' '.wav')
					withCaption: 'Choose a sound track file'.
	fileName == nil ifTrue: [^ self].
	soundTrackFileName _ fileName.
	self tryToShareScoreFor: soundTrackFileName.
	scorePlayer ifNil:
		[('*aif' match: fileName) ifTrue:
			[scorePlayer _ SampledSound fromAIFFfileNamed: fileName].
		('*wav' match: fileName) ifTrue:
			[scorePlayer _ SampledSound fromWaveFileNamed: fileName]].
	soundTrackForm ifNotNil:
		["Compute new soundTrack if we're showing it."
		self showHideSoundTrack; showHideSoundTrack]