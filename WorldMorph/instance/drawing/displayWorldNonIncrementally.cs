displayWorldNonIncrementally
	"Display the morph world non-incrementally. Used for testing."

	(canvas == nil or:
	 [(canvas extent ~= viewBox extent) or:
	 [canvas form depth ~= Display depth]]) ifTrue: [
		"allocate a new offscreen canvas the size of the window"
		self canvas: (FormCanvas extent: viewBox extent)].

	canvas fillColor: color.
	submorphs reverseDo: [:m | m fullDrawOn: canvas].
	hands reverseDo: [:h | h fullDrawOn: canvas].
	canvas form displayOn: Display at: viewBox origin.
	self fullRepaintNeeded.  "don't collect damage"
	Smalltalk forceDisplayUpdate.

