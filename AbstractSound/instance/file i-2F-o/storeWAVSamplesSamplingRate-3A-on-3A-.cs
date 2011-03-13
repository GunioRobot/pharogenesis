storeWAVSamplesSamplingRate: rate on: aBinaryStream
	"Write WAV sound file. Stereo, 16 bit. At the appropiate sampling rate."

	| bufferSize buffer fullBufferCount lastBufferSize finalSampleCount |

	self reset.
	finalSampleCount _ (self duration * self samplingRate) ceiling.
	bufferSize _ self samplingRate rounded min: finalSampleCount.	"One second. Could be any size."
	fullBufferCount _ finalSampleCount // bufferSize.
	lastBufferSize _ finalSampleCount \\ bufferSize.

	"File header"
	aBinaryStream
		nextPutAll: 'RIFF' asByteArray;
		nextLittleEndianNumber: 4 put: finalSampleCount * 4 + 36;	"Lenght of all chunks"
		nextPutAll: 'WAVE' asByteArray.

	"Format Chunk"
	aBinaryStream
		nextPutAll: 'fmt ' asByteArray;
		nextLittleEndianNumber: 4 put: 16;		"Lenght of this chunk"
		nextLittleEndianNumber: 2 put: 1;		"Format tag"
		nextLittleEndianNumber: 2 put: 2;		"Channel count"
		nextLittleEndianNumber: 4 put: self samplingRate rounded;		"Samples per sec"
		nextLittleEndianNumber: 4 put: self samplingRate rounded * 4;	"Bytes per sec"
		nextLittleEndianNumber: 2 put: 4;		"Alignment"
		nextLittleEndianNumber: 2 put: 16.		"Bits per sample"

	"Data chunk"
	aBinaryStream
		nextPutAll: 'data' asByteArray;
		nextLittleEndianNumber: 4 put: finalSampleCount * 4.		"Lenght of this chunk"

	fullBufferCount timesRepeat: [
		buffer _ SoundBuffer newStereoSampleCount: bufferSize.
		self playSampleCount: bufferSize into: buffer startingAt: 1.
		buffer do: [ :sample |
			aBinaryStream nextLittleEndianNumber: 2 put: sample \\ 65536 ].
	].
	buffer _ SoundBuffer newStereoSampleCount: lastBufferSize.
	self playSampleCount: lastBufferSize into: buffer startingAt: 1.
	buffer do: [ :sample |
		aBinaryStream nextLittleEndianNumber: 2 put: sample \\ 65536].