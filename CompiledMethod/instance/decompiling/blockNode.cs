blockNode

	BlockNodeCache key == self ifTrue: [^ BlockNodeCache value].
	^ self blockNodeIn: nil