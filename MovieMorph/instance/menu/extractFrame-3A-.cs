extractFrame: evt

	| f |
	f _ self currentFrame.
	f ifNil: [^ self].
	frameList _ frameList copyWithout: f.
	frameList isEmpty
		ifTrue: [self position: f position]
		ifFalse: [self setFrame: currentFrameIndex].
	evt hand attachMorph: f.
