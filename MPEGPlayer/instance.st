Object
	subclass: #MPEGPlayer
	instanceVariableNames:
		'external form startTime clockBias frameRate lastDelay noSound sampleRate audioPlayerProcess videoPlayerProcess playerProcessPriority soundQueue timeCheck semaphoreForSound errorForSoundStart morph volume buffer isBuffer'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Movies-Kernel'