fromReader: reader
	images _ reader forms.
	delays _ reader delays.
	imageIndex _ 0.
	self image: (Form extent: images first extent depth: 32).
	self step