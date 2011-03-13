jpegMovieSize: quality
	"Convert all my frames to a JPEG and measure the total size."

	| jpegSize jpegDecodeTime jpegStream t outForm |
	mpegFile hasVideo ifFalse: [^ self error: 'movie has no video'].
	jpegSize := 0.
	jpegDecodeTime := 0.
	jpegStream := WriteStream on: (ByteArray new: 100000).
	self rewindMovie.

	[(mpegFile videoGetFrame: 0) < (mpegFile videoFrames: 0)] whileTrue: [
		jpegStream reset.
		(JPEGReadWriter2 on: jpegStream)
			nextPutImage: frameBuffer
			quality: quality
			progressiveJPEG: false.
		jpegSize := jpegSize + jpegStream position.
		t := [
			outForm := (JPEGReadWriter2 on: (ReadStream on: jpegStream contents)) nextImage
		] timeToRun.
		jpegDecodeTime := jpegDecodeTime + t.
		outForm display.
		frameBuffer displayAt: (outForm width + 10)@0.
		self nextFrame].

	^ Array with: jpegSize with: jpegDecodeTime with: (mpegFile videoFrames: 0)

