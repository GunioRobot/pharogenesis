tapDelays: delayList gains: gainList
	"ReverbSound new tapDelays: #(537 691 1191) gains: #(0.07 0.07 0.07)"

	| maxDelay gain d |
	delayList size = gainList size
		ifFalse: [self error: 'tap delay and gains lists must be the same size'].
	tapCount _ delayList size.
	tapDelays _ Bitmap new: tapCount.
	tapGains _ Bitmap new: tapCount.

	maxDelay _ 0.
	1 to: tapGains size do: [:i |
		tapDelays at: i put: (delayList at: i) asInteger.
		gain _ gainList at: i.
		gain >= 1.0 ifTrue: [self error: 'reverb tap gains must be under 1.0'].
		tapGains at: i put: (gain * ScaleFactor) asInteger.
		d _ tapDelays at: i.
		d > maxDelay ifTrue: [maxDelay _ d]].
	bufferSize _ maxDelay.
	leftBuffer _ SoundBuffer newMonoSampleCount: maxDelay.
	rightBuffer _ SoundBuffer newMonoSampleCount: maxDelay.
	bufferIndex _ 1.
