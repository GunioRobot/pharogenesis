copySounds
	"Private! Support for copying. Copy my component sounds and settings array."

	sounds _ sounds collect: [:s | s copy].
	leftVols _ leftVols copy.
	rightVols _ rightVols copy.
