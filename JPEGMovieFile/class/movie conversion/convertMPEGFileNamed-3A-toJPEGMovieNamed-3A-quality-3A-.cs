convertMPEGFileNamed: mpegFileName toJPEGMovieNamed: jpegFileName quality: quality
	"Convert the MPEG movie with the given file name into a JPEG movie with the given file name."

	| mpegFile jpegFile soundtrackCount movieExtent frameOffsets soundTrackOffsets |
	(FileDirectory default fileExists: mpegFileName)
		ifFalse: [^ self inform: 'File not found: ', mpegFileName].
	(MPEGFile isFileValidMPEG: mpegFileName)
		ifFalse: [^ self inform: 'Not an MPEG file: ', mpegFileName].
	mpegFile _ MPEGFile openFile: mpegFileName.
	mpegFile fileHandle ifNil: [^ self inform: 'Could not open ', mpegFileName].
	jpegFile _ (FileStream newFileNamed: jpegFileName) binary.

	"write header"
	soundtrackCount _ mpegFile hasAudio ifTrue: [1] ifFalse: [0].
	mpegFile hasVideo
		ifTrue: [
			movieExtent _ (mpegFile videoFrameWidth: 0)@(mpegFile videoFrameHeight: 0).
			self writeHeaderExtent: movieExtent
				frameRate: (mpegFile videoFrameRate: 0)
				frameCount: (mpegFile videoFrames: 0)
				soundtrackCount: soundtrackCount
				on: jpegFile]
		ifFalse: [
			self writeHeaderExtent: 0@0
				frameRate: 0
				frameCount: 0
				soundtrackCount: soundtrackCount
				on: jpegFile].

	"convert and write frames"
	frameOffsets _ self writeFramesFrom: mpegFile on: jpegFile quality: quality.
	self updateFrameOffsets: frameOffsets on: jpegFile.

	"convert and write sound tracks"
	jpegFile position: frameOffsets last.  "store sound tracks after the last frame"
	soundTrackOffsets _ self writeSoundTracksFrom: mpegFile on: jpegFile.
	self updateSoundtrackOffsets: soundTrackOffsets frameOffsets: frameOffsets on: jpegFile.

	mpegFile closeFile.
	jpegFile close.
	Display restore.
