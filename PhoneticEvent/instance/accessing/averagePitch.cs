averagePitch
	| sum previous |
	self pitchPoints size = 1 ifTrue: [^ self pitchPoints first y].
	sum _ 0.0.
	self pitchPoints do: [ :each |
		previous isNil ifFalse: [sum _ (each y + previous y) / 2.0 * (each x - previous x) + sum].
		previous _ each].
	sum _ previous y * (self duration - previous x) + sum.
	^ sum / self duration