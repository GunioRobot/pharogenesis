initializeIn: bounds
	handle _ self primCreateRenderer: self defaultFlags 
		x: bounds left y: bounds top w: bounds width h: bounds height.
	bufRect _ bounds.
	handle ifNil:[^nil].
	self initializeTarget.
	^self