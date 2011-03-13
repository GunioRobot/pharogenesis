step
	| d |
	images isEmpty ifTrue: [^ self].
		
	nextTime > Time millisecondClockValue
		ifTrue: [^self].
	self changed .
	self image: (images at:
	(imageIndex _ imageIndex \\ images size + 1)).
	self changed . 
	d _ (delays at: imageIndex) ifNil: [0].
	nextTime := Time millisecondClockValue + d
