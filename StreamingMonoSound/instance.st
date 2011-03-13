AbstractSound
	subclass: #StreamingMonoSound
	instanceVariableNames:
		'stream volume repeat headerStart audioDataStart streamSamplingRate totalSamples codec mixer leftoverSamples lastBufferMSecs mutex'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Sound-Synthesis'