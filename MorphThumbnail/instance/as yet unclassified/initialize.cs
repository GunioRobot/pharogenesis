initialize

	| f |
	super initialize.
	color _ Color lightGray.  "background color"
	f _ Form extent: 60@80 depth: Display depth.
	f fill: f boundingBox fillColor: color.
	self form: f
