updateSoundtrackOffsets: soundtrackOffsetList frameOffsets: frameOffsets on: aBinaryStream
	"Update the JPEG movie file header on the given stream with the given sequence of sound track offsets."

	aBinaryStream position: 22 + (4 * frameOffsets size).
	aBinaryStream uint16: soundtrackOffsetList size.
	soundtrackOffsetList do: [:offset | aBinaryStream uint32: offset].
