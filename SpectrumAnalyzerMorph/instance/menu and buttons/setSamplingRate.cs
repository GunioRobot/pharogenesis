setSamplingRate
	"Set the sampling rate to be used for incoming sound data."

	| aMenu rate on |
	aMenu _ CustomMenu new title:
		'Sampling rate (currently ', soundInput samplingRate printString, ')'.
	#(11025 22050 44100) do:[:r | aMenu add: r printString action: r].
	rate _ aMenu startUp.
	rate ifNil: [^ self].
	on _ soundInput isRecording.
	self stop.
	soundInput samplingRate: rate.
	self resetDisplay.
	on ifTrue: [self start].

