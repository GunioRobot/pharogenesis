fromWaveFileNamed: fileName
	"(SampledSound fromWaveFileNamed: 'c:\windows\media\chimes.wav') play"
	"| snd fd |
	fd := FileDirectory on:'c:\windows\media\'.
	fd fileNames do: [:n |
		(n asLowercase endsWith: '.wav')
			ifTrue: [
				snd _ SampledSound fromWaveFileNamed: (fd pathName,n).
				snd play.
				SoundPlayer waitUntilDonePlaying: snd]]."
	| header stream data type channels samplingRate blockAlign bitsPerSample 
	leftData rightData index dataWord |
	stream := FileStream oldFileNamed: fileName.
	header := self readWaveChunk:'fmt ' inRIFF: stream.
	data := self readWaveChunk: 'data' inRIFF: stream.
	stream close.
	stream := ReadStream on: header.
	type := self next16BitWord: false from: stream.
	type = 1 ifFalse:[^self error:'Unexpected wave format'].
	channels := self next16BitWord: false from: stream.
	(channels < 1 or:[channels > 2]) ifTrue:[^self error:'Unexpected number of wave channels'].
	samplingRate := self next32BitWord: false from: stream.
	stream skip: 4. "Skip average bytes per second"
	blockAlign := self next16BitWord: false from: stream.
	bitsPerSample := self next16BitWord: false from: stream.
	(bitsPerSample = 8 or:[bitsPerSample = 16]) ifFalse:[
		"Recompute bits per sample"
		bitsPerSample := (blockAlign // channels) * 8.
	].
	bitsPerSample = 8 ifTrue:[
		data := self convert8bitUnsignedTo16Bit: data.
	].
	channels = 2 ifTrue:[
		leftData := SoundBuffer newMonoSampleCount: data size.
		rightData := SoundBuffer newMonoSampleCount: data size.
		stream := ReadStream on: data.
		index := 1.
		[stream atEnd] whileFalse:[
			dataWord := self next16BitWord: false from: stream.
			dataWord > 16r8000 ifTrue:[dataWord := dataWord - 16r10000].
			leftData at: index put: dataWord.
			dataWord := self next16BitWord: false from: stream.
			dataWord > 16r8000 ifTrue:[dataWord := dataWord - 16r10000].
			rightData at: index put: dataWord.
			index := index + 1.
		].
		^(MixedSound new)
			add: (self samples: leftData samplingRate: samplingRate) pan: 0.0;
			add: (self samples: rightData samplingRate: samplingRate) pan: 1.0;
		yourself
	].
	^self samples: data samplingRate: samplingRate.