lastTime
	| last |
	self isEmpty ifTrue: [^ 0].
	last := self timedEvents last.
	^ last key + (last value duration * 1000) rounded