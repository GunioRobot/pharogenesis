playOn: aVoice at: time
	self timedEvents do: [ :each | each value playOn: aVoice at: each key + time].
	aVoice flush