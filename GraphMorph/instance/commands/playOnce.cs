playOnce

	| scale absV scaledData |
	data isEmpty ifTrue: [^ self].  "nothing to play"
	scale _ 1.
	data do: [:v | (absV _ v abs) > scale ifTrue: [scale _ absV]].
	scale _ 32767.0 / scale.
	scaledData _ SoundBuffer newMonoSampleCount: data size.
	1 to: data size do: [:i | scaledData at: i put: (scale * (data at: i)) truncated].
	SoundService default playSampledSound: scaledData rate: 11025.
