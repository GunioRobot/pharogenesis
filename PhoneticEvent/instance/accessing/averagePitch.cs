averagePitch
	| sum previous |
	self pitchPoints size = 1 ifTrue: [^ self pitchPoints first y].
	sum := 0.0.
	self pitchPoints do: [ :each |
		previous isNil ifFalse: [sum := (each y + previous y) / 2.0 * (each x - previous x) + sum].
		previous := each].
	sum := previous y * (self duration - previous x) + sum.
	^ sum / self duration