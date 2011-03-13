AbstractSound
	subclass: #StreamingMP3Sound
	instanceVariableNames:
		'volume repeat mpegFile mpegStreamIndex totalSamples streamSamplingRate mixer lastBufferMSecs mutex'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Movies-Kernel'