computeThumbnail

	| f scale |
	f _ page imageForm.
	scale _ self height / f height.  "keep height invariant"
	self form: (f magnify: f boundingBox by: scale@scale smoothing: 2).
