updateFrameOffsets: frameOffsets on: aBinaryStream
	"Update the JPEG movie file header on the given stream with the given collection of frame offsets."

	aBinaryStream position: 22.
	frameOffsets do: [:offset | aBinaryStream uint32: offset].
