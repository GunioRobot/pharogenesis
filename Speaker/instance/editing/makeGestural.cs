makeGestural
	(self findAVoice: GesturalVoice) isNil ifFalse: [^ self].
	self voice: self voice + GesturalVoice new