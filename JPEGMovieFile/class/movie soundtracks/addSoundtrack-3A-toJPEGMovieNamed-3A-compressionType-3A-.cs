addSoundtrack: soundFileName toJPEGMovieNamed: jpegFileName compressionType: compressionTypeString
	"Append the given audio file as a soundtrack the given JPEG movie using the given compression type ('none', 'adpcm3', 'adpcm4', 'adpcm5', 'mulaw', or 'gsm')."
	"Note: While the Squeak JPEG movie format supports multiple soundtracks, the player currently plays only the first soundtrack."

	| snd jpegFile outFile frameCount newFrameOffsets buf inFile newSoundtrackOffsets oldMovieName |
	snd := StreamingMonoSound onFileNamed: soundFileName.
	jpegFile := JPEGMovieFile new openFileNamed: jpegFileName.
	outFile := (FileStream newFileNamed: 'movie.tmp') binary.
	frameCount := jpegFile videoFrames: 0.

	"write new header"
	self
		writeHeaderExtent: ((jpegFile videoFrameWidth: 0)@(jpegFile videoFrameHeight: 0))
		frameRate: (jpegFile videoFrameRate: 0)
		frameCount: frameCount
		soundtrackCount: (jpegFile soundtrackOffsets size + 1)
		on: outFile.

	"copy frames to new file"
	newFrameOffsets := Array new: frameCount + 1.
	1 to: frameCount do: [:i |
		newFrameOffsets at: i put: outFile position.
		buf := jpegFile bytesForFrame: i.
		outFile nextPutAll: buf].
	newFrameOffsets at: frameCount + 1 put: outFile position.

	"copy existing soundtracks, if any, to new file"
	jpegFile soundtrackOffsets size > 0 ifTrue: [
		inFile := jpegFile fileHandle.
		inFile position: jpegFile soundtrackOffsets first.
		buf := ByteArray new: 10000.
		[inFile atEnd] whileFalse: [
			buf := inFile next: buf size into: buf startingAt: 1.
			outFile nextPutAll: buf]].

	"adjust soundtrack offsets for header size increase and add new one:"
	newSoundtrackOffsets := jpegFile soundtrackOffsets collect: [:n | n + 4].
	newSoundtrackOffsets := newSoundtrackOffsets copyWith: outFile position.
	snd storeSunAudioOn: outFile compressionType: compressionTypeString.

	"update header:"
	self updateFrameOffsets: newFrameOffsets on: outFile.
	self updateSoundtrackOffsets: newSoundtrackOffsets frameOffsets: newFrameOffsets on: outFile.

	"close files"
	snd closeFile.
	jpegFile closeFile.
	outFile close.

	"replace the old movie with the new version"
	oldMovieName := (jpegFile fileName copyFrom: 1 to: (jpegFile fileName size - 4)), '.old'.
	FileDirectory default deleteFileNamed: oldMovieName.
	FileDirectory default rename: jpegFile fileName toBe: oldMovieName.
	FileDirectory default rename: 'movie.tmp' toBe: jpegFile fileName.
