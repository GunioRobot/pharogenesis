font: aTTFontDescription
	font _ aTTFontDescription.
	string ifNil: [self string: aTTFontDescription fullName]
		ifNotNil: [self initializeString].