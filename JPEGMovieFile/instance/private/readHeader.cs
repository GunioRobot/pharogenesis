readHeader
	"Read a JPEG movie header file."
	"Details: The file structures is:
		<header, including sequence frame offsets>
		<sequence of JPEG compressed images>
		<optional soundtracks>"

	| tag w h frameOffsetCount soundtrackCount |
	file position: 0.
	tag _ (file next: 10) asString.
	tag = 'JPEG Movie' ifFalse: [self error: 'not a JPEG movie file'].
	w _ file uint16.
	h _ file uint16.
	movieExtent _ w @ h.
	frameRate _ file uint32 / 10000.0.
	frameOffsetCount _ file uint32.
	frameOffsets _ Array new: frameOffsetCount.
	1 to: frameOffsetCount do: [:i | frameOffsets at: i put: file uint32].
	soundtrackCount _ file uint16.
	soundtrackOffsets _ Array new: soundtrackCount.
	1 to: soundtrackCount do: [:i | soundtrackOffsets at: i put: file uint32].
