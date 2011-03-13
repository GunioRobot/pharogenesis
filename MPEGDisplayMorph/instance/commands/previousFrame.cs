previousFrame
	"Go to the previous frame."

	| n |
	mpegFile ifNil: [^ self].
	running ifTrue: [^ self].
	n := (mpegFile videoGetFrame: 0) - 2.
	n := (n min: ((mpegFile videoFrames: 0) - 3)) max: 0.
	mpegFile videoSetFrame: n stream: 0.
	self nextFrame.
