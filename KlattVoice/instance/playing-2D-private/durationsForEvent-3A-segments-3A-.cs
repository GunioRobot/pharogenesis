durationsForEvent: event segments: segs
	| scale |
	scale := event duration / ((segs inject: 0 into: [ :result :each | result + each duration]) * 10 / 1000.0).
	^ segs collect: [ :each | (each duration * scale) rounded]