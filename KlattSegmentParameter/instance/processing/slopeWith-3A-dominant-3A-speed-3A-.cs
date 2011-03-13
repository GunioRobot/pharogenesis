slopeWith: parameter dominant: dominant speed: speed
	| dominated time value |
	dominated := self == dominant ifTrue: [parameter] ifFalse: [self].
	time := dominant == self ifTrue: [dominant internal] ifFalse: [dominant external].
	time := time * speed.
	value := time ~= 0
		ifTrue: [dominant proportion * dominated steady * 0.01 + dominant fixed]
		ifFalse: [dominated steady].
	^ time @ value