displayWorldNonIncrementally
	"Display the morph world non-incrementally. Used for testing."

	(self canvas == nil or:
	 [(self canvas extent ~= self viewBox extent) or:
	 [self canvas form depth ~= Display depth]]) ifTrue: [
		"allocate a new offscreen canvas the size of the window"
		self canvas: (Display defaultCanvasClass extent: self viewBox extent)].

	self canvas fillColor: color.
	submorphs reverseDo: [:m | m fullDrawOn: self canvas].
	self hands reverseDo: [:h | h fullDrawOn: self canvas].
	self canvas form displayOn: Display at: self viewBox origin.
	self fullRepaintNeeded.  "don't collect damage"
	Display forceDisplayUpdate.
