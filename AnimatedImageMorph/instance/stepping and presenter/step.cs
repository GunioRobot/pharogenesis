step
	| f d |
	images isEmpty
		ifTrue: [^ self].
	nextTime > Time millisecondClockValue
		ifTrue: [^self].
	imageIndex _ imageIndex \\ images size + 1.
	f _ images at: imageIndex.
	f displayOn: self image at: 0@0 rule: Form paint.
	self invalidRect: (self position + f offset extent: f extent).
	d _ (delays at: imageIndex) ifNil: [0].
	nextTime := Time millisecondClockValue + d
