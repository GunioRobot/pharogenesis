readHeader
	"Read a JPEG movie header file."
	"Details: The file structures is:
		<header, including sequence frame offsets>
		<sequence of JPEG compressed images>
		<optional soundtracks>"

	| tag w h frameOffsetCount soundtrackCount |
	file position: 0.
	tag := (file next: 10) asString.
	tag = 'JPEG Movie' ifFalse: [self error: 'not a JPEG movie file'].
	w := file uint16.
	h := file uint16.
	movieExtent := w @ h.
	frameRate := file uint32 / 10000.0.
	frameOffsetCount := file uint32.
	frameOffsets := Array new: frameOffsetCount.
	1 to: frameOffsetCount do: [:i | frameOffsets at: i put: file uint32].
	soundtrackCount := file uint16.
	soundtrackOffsets := Array new: soundtrackCount.
	1 to: soundtrackCount do: [:i | soundtrackOffsets at: i put: file uint32].
