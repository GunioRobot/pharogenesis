nextFrame
	"Fetch the next frame into the frame buffer."

	mpegFile ifNil: [^ self].
	mpegFile videoReadFrameInto: frameBuffer stream: 0.
	self changed.
