startPlaying
	"Start playing the movie at the current position."

	| frameIndex |
	self stopPlaying.
	stopFrame _ nil.
	self mpegFileIsOpen ifFalse: [^ self].

	(FileStream isAFileNamed: mpegFile fileName) ifFalse: [ | newFileResult newFileName |
		self inform: 'Path changed. Enter new one for: ', (FileDirectory localNameFor: mpegFile fileName).
		newFileResult _ StandardFileMenu oldFile.
		newFileName _ newFileResult directory fullNameFor: newFileResult name.	
		mpegFile openFile: newFileName].
	
	mpegFile hasAudio
		ifTrue:
			[mpegFile hasVideo ifTrue:
				["set movie frame position from soundTrack position"
				soundTrack reset.  "ensure file is open before positioning"
				soundTrack soundPosition: (mpegFile videoGetFrame: 0) asFloat / (mpegFile videoFrames: 0).
				"now set frame index from the soundtrack position for best sync"
				frameIndex _ ((soundTrack millisecondsSinceStart * desiredFrameRate) // 1000).
				frameIndex _ (frameIndex max: 0) min: ((mpegFile videoFrames: 0) - 3).
				mpegFile videoSetFrame: frameIndex stream: 0].

			SoundPlayer stopReverb.
			soundTrack volume: volume.
			soundTrack repeat: repeat.
			soundTrack resumePlaying.
			startFrame _ startMSecs _ 0]
		ifFalse:
			[soundTrack _ nil.
			startFrame _ mpegFile videoGetFrame: 0.
			startMSecs _ Time millisecondClockValue].
	running _ true