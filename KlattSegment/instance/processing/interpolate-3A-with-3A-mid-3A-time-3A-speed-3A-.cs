interpolate: slope1 with: slope2 mid: mid time: time speed: speed
	| steady p1 p2 |
	steady := self duration * speed - (slope1 x + slope2 x).
	steady < 0 "steady state cannot be reached"
		ifTrue: [p1 := self linear: slope1 y with: mid time: time duration: slope1 x.
				p2 := self linear: slope2 y with: mid time: self duration * speed - time duration: slope2 x.
				^ p2 - p1 * time / (self duration * speed) + p1].
	time < slope1 x
		ifTrue: [^ self linear: slope1 y with: mid time: time duration: slope1 x].
	^ time - slope1 x <= steady "steady state reached"
		ifTrue: [mid]
		ifFalse: [self linear: mid with: slope2 y time: time - slope1 x - steady duration: slope2 x]