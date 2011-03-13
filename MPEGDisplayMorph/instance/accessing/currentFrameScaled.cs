currentFrameScaled
	"Answer a Form containing the current frame scaled to my current size."

	| f |
	f := Form extent: self extent depth: 32.
	frameBuffer ifNil: [^ f fillColor: (Color gray: 0.75)].
	self drawScaledOn: ((FormCanvas on: f) copyOffset: self topLeft negated).
	^ f