primSoundStartBufferSize: bufferSize rate: samplesPerSecond stereo: stereoFlag
	"Start double-buffered sound output with the given buffer size and sampling rate. This version has been superceded by primitive 171 (primSoundStartBufferSize:rate:stereo:semaIndex:)."

	<primitive: 170>
	^ self primitiveFailed
