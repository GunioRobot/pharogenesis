openFileNamed: mpegFileName
	"Try to open the MPEG file with the given name. Answer true if successful."

	| e |
	self closeFile.
	(FileDirectory default fileExists: mpegFileName)
		ifFalse: [self inform: ('File not found: {1}' translated format: {mpegFileName}). ^ false].

	(MPEGFile isFileValidMPEG: mpegFileName)
		ifTrue: [mpegFile := MPEGFile openFile: mpegFileName]
		ifFalse: [
			(JPEGMovieFile isJPEGMovieFile: mpegFileName)
				ifTrue: [mpegFile := JPEGMovieFile new openFileNamed: mpegFileName]
				ifFalse: [self inform: ('Not an MPEG or JPEG movie file: {1}' translated format: {mpegFileName}). ^ false]].
	mpegFile fileHandle ifNil: [^ false].

	"initialize soundTrack"
	mpegFile hasAudio
		ifTrue: [soundTrack := mpegFile audioPlayerForChannel: 1]
		ifFalse: [soundTrack := nil].

	mpegFile hasVideo
		ifTrue: [  "set screen size and display first frame"
			desiredFrameRate := mpegFile videoFrameRate: 0.
			soundTrack ifNotNil: [  "compute frame rate from length of audio track"
				desiredFrameRate := (mpegFile videoFrames: 0) / soundTrack duration].
			e := (mpegFile videoFrameWidth: 0)@(mpegFile videoFrameHeight: 0).
			frameBuffer := Form extent: e depth: (Display depth max: 16).
			super extent: e.
			self nextFrame]
		ifFalse: [  "hide screen for audio-only files"
			super extent: 250@0].
