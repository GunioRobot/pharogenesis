openWaveEditor

	| scaleFactor scaledData editor |
	self data: data.  "make sure maxVal and minVal are current"
	scaleFactor _ 32767 // ((minVal abs max: maxVal abs) max: 1).
	scaledData _ SoundBuffer newMonoSampleCount: data size.
	1 to: data size do: [:i | scaledData at: i put: (scaleFactor * (data at: i)) truncated].
	editor _ WaveEditor new
		data: scaledData;
		samplingRate: 11025;
		perceivedFrequency: 220.0.
	editor openInWorld.
