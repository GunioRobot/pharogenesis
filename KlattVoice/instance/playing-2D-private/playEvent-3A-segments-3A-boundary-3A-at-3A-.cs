playEvent: event segments: segs boundary: boundarySegment at: time
	| frames stream dur durations |
	frames := OrderedCollection new.
	stream := ReadStream on: segs.
	durations := ReadStream on: (self durationsForEvent: event segments: segs).
	[stream atEnd]
		whileFalse: [current := stream next.
					dur := durations next.
					dur > 0
						ifTrue: [right := stream atEnd ifTrue: [boundarySegment] ifFalse: [stream peek].
								frames addAll: (self currentFramesCount: dur)].
					left := current].
	frames isEmpty ifTrue: [^ self].
	self playEvent: event frames: frames at: time