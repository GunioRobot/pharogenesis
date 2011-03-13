Object
	subclass: #SoundRecorder
	instanceVariableNames:
		'stereo samplingRate recordLevel recordedBuffers recordedSound recordProcess bufferAvailableSema paused meteringBuffer meterLevel soundPlaying currentBuffer nextIndex codec desiredSampleRate '
	classVariableNames: 'CanRecordWhilePlaying RecorderActive '
	poolDictionaries: ''
	category: 'Sound-Synthesis'