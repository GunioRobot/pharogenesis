transformSounds: tfmBlock
	"Private! Support for copying. Copy my component sounds."

	sounds _ sounds collect: [:s | tfmBlock value: s].
