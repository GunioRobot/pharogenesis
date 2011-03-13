fullDrawOn: aCanvas
	self installed ifFalse: [self drawOn: aCanvas]