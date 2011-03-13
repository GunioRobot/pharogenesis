startPlaying
	"Start playing the movie at the current position."

	| frameIndex |
	self stopPlaying.
	stopFrame := nil.
	self mpegFileIsOpen ifFalse: [^ self].

	(FileStream isAFileNamed: mpegFile fileName) ifFalse: [ | newFileResult newFileName |
		self inform: 'Path changed. Enter new one for: ', (FileDirectory localNameFor: mpegFile fileName).
		newFileResult := StandardFileMenu oldFile.
		newFileName := newFileResult directory fullNameFor: newFileResult name.	
		mpegFile openFile: newFileName].
	
	mpegFile hasAudio
		ifTrue:
			[mpegFile hasVideo ifTrue:
				["set movie frame position from soundTrack position"
				soundTrack reset.  "ensure file is open before positioning"
				soundTrack soundPosition: (mpegFile videoGetFrame: 0) asFloat / (mpegFile videoFrames: 0).
				"now set frame index from the soundtrack position for best sync"
				frameIndex := ((soundTrack millisecondsSinceStart * desiredFrameRate) // 1000).
				frameIndex := (frameIndex max: 0) min: ((mpegFile videoFrames: 0) - 3).
				mpegFile videoSetFrame: frameIndex stream: 0].

			SoundPlayer stopReverb.
			soundTrack volume: volume.
			soundTrack repeat: repeat.
			soundTrack resumePlaying.
			startFrame := startMSecs := 0]
		ifFalse:
			[soundTrack := nil.
			startFrame := mpegFile videoGetFrame: 0.
			startMSecs := Time millisecondClockValue].
	running := true