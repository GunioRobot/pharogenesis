lastTime
	| last |
	self isEmpty ifTrue: [^ 0].
	last _ self timedEvents last.
	^ last key + (last value duration * 1000) rounded