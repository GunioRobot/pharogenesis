smear: dir distance: dist
	"Smear any black pixels in this form in the direction dir in Log N steps"
	| skew bb |
	bb _ BitBlt current destForm: self sourceForm: self fillColor: nil
		combinationRule: Form under destOrigin: 0@0 sourceOrigin: 0@0
		extent: self extent clipRect: self boundingBox.
	skew _ 1.
	[skew < dist] whileTrue:
		[bb destOrigin: dir*skew; copyBits.
		skew _ skew+skew]