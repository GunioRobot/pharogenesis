slopeWith: parameter dominant: dominant speed: speed
	| dominated time value |
	dominated _ self == dominant ifTrue: [parameter] ifFalse: [self].
	time _ dominant == self ifTrue: [dominant internal] ifFalse: [dominant external].
	time _ time * speed.
	value _ time ~= 0
		ifTrue: [dominant proportion * dominated steady * 0.01 + dominant fixed]
		ifFalse: [dominated steady].
	^ time @ value