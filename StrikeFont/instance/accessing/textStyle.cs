textStyle
	^ Utilities actualTextStyles detect:
		[:aStyle | aStyle fontArray includes: self] ifNone: [nil]