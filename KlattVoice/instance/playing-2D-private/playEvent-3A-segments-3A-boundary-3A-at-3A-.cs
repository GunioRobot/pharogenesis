playEvent: event segments: segs boundary: boundarySegment at: time
	| frames stream dur durations |
	frames _ OrderedCollection new.
	stream _ ReadStream on: segs.
	durations _ ReadStream on: (self durationsForEvent: event segments: segs).
	[stream atEnd]
		whileFalse: [current _ stream next.
					dur _ durations next.
					dur > 0
						ifTrue: [right _ stream atEnd ifTrue: [boundarySegment] ifFalse: [stream peek].
								frames addAll: (self currentFramesCount: dur)].
					left _ current].
	frames isEmpty ifTrue: [^ self].
	self playEvent: event frames: frames at: time