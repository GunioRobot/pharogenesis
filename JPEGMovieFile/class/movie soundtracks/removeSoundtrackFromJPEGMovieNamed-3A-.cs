removeSoundtrackFromJPEGMovieNamed: jpegFileName
	"Remove all soundtracks from the JPEG movie with the given name."

	| jpegFile outFile frameCount newFrameOffsets buf oldMovieName |
	jpegFile _ JPEGMovieFile new openFileNamed: jpegFileName.
	outFile _ (FileStream newFileNamed: 'movie.tmp') binary.
	frameCount _ jpegFile videoFrames: 0.

	"write new header"
	self
		writeHeaderExtent: ((jpegFile videoFrameWidth: 0)@(jpegFile videoFrameHeight: 0))
		frameRate: (jpegFile videoFrameRate: 0)
		frameCount: frameCount
		soundtrackCount: 0
		on: outFile.

	"copy frames to new file"
	newFrameOffsets _ Array new: frameCount + 1.
	1 to: frameCount do: [:i |
		newFrameOffsets at: i put: outFile position.
		buf _ jpegFile bytesForFrame: i.
		outFile nextPutAll: buf].
	newFrameOffsets at: frameCount + 1 put: outFile position.

	"update header:"
	self updateFrameOffsets: newFrameOffsets on: outFile.

	"close files"
	jpegFile closeFile.
	outFile close.

	"replace the old movie with the new version"
	oldMovieName _ (jpegFile fileName copyFrom: 1 to: (jpegFile fileName size - 4)), '.old'.
	FileDirectory default deleteFileNamed: oldMovieName.
	FileDirectory default rename: jpegFile fileName toBe: oldMovieName.
	FileDirectory default rename: 'movie.tmp' toBe: jpegFile fileName.
