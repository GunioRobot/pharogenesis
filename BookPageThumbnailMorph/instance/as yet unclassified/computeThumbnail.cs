computeThumbnail
	| f scale |
	self objectsInMemory.
	f _ page imageForm.
	scale _ (self height / f height).  "keep height invariant"
"(Sensor shiftPressed) ifTrue: [scale _ scale * 1.4]."
	self form: (f magnify: f boundingBox by: scale@scale smoothing: 2).

