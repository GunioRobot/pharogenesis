Object
	subclass: #SoundRecorder
	instanceVariableNames:
		'stereo samplingRate recordedBuffers recordProcess bufferAvailableSema paused meteringBuffer meterLevel soundPlaying currentBuffer nextIndex '
	classVariableNames: 'CanRecordWhilePlaying '
	poolDictionaries: ''
	category: 'System-Sound'