includes: aDateAndTime

	| dt |
	dt _ aDateAndTime asDateAndTime.
	self scheduleDo: [ :e | e = dt ifTrue: [^true] ].
	^ false.
