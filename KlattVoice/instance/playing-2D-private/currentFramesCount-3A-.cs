currentFramesCount: n
	| answer |
	answer _ current left: left right: right speed: n / current duration asFloat pattern: self patternFrame.
	answer size > 0 ifTrue: [self patternFrame: answer last].
	^ answer