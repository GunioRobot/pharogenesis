loadSoundData: aCollection

	| scale absV newData |
	scale _ 0.
	aCollection do: [:v | (absV _ v abs) > scale ifTrue: [scale _ absV]].
	scale _ 100.0 / scale.
	newData _ OrderedCollection new: aCollection size.
	1 to: aCollection size do: [:i | newData addLast: (scale * (aCollection at: i))].

	self data: newData.
	self startIndex: 1.
	self cursor: 1.
