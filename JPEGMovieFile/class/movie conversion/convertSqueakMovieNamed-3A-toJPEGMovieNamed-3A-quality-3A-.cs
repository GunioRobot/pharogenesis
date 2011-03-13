convertSqueakMovieNamed: squeakMovieFileName toJPEGMovieNamed: jpegFileName quality: quality
	"Convert the Squeak movie with the given file name into a JPEG movie with the given file name."

	| sqMovieFile jpegFile w h d frameCount mSecsPerFrame frameForm bytesPerFrame frameOffsets |
	(FileDirectory default fileExists: squeakMovieFileName)
		ifFalse: [^ self inform: 'File not found: ', squeakMovieFileName].
	sqMovieFile := (FileStream readOnlyFileNamed: squeakMovieFileName) binary.
	sqMovieFile ifNil: [^ self inform: 'Could not open ', squeakMovieFileName].
	jpegFile := (FileStream newFileNamed: jpegFileName) binary.

	sqMovieFile nextInt32.  "skip first word"
	w := sqMovieFile nextInt32.
	h := sqMovieFile nextInt32.
	d := sqMovieFile nextInt32.
	frameCount := sqMovieFile nextInt32.
	mSecsPerFrame := (sqMovieFile nextInt32) / 1000.0.

	"write header"
	self writeHeaderExtent: w@h
		frameRate: (1000.0 / mSecsPerFrame)
		frameCount: frameCount
		soundtrackCount: 0
		on: jpegFile.

	"convert and write frames"
	frameForm := Form extent: w@h depth: d.
	bytesPerFrame := 4 + (frameForm bits size * 4).
	frameOffsets := Array new: frameCount + 1.
	1 to: frameCount do: [:i |
		frameOffsets at: i put: jpegFile position.
		sqMovieFile position: 128 + ((i - 1) * bytesPerFrame) + 4.
		sqMovieFile next: frameForm bits size into: frameForm bits startingAt: 1.
		frameForm display.
		self writeFrame: frameForm on: jpegFile quality: quality displayFlag: false].
	frameOffsets at: (frameCount + 1) put: jpegFile position.
	self updateFrameOffsets: frameOffsets on: jpegFile.

	sqMovieFile close.
	jpegFile close.
	Display restore.
