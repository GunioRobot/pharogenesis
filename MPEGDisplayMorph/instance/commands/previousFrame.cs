previousFrame
	"Go to the previous frame."

	| n |
	mpegFile ifNil: [^ self].
	running ifTrue: [^ self].
	n _ (mpegFile videoGetFrame: 0) - 2.
	n _ (n min: ((mpegFile videoFrames: 0) - 3)) max: 0.
	mpegFile videoSetFrame: n stream: 0.
	self nextFrame.
