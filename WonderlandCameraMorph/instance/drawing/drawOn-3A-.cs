drawOn: aCanvas 
	aCanvas asBalloonCanvas render: self.
	self outline ifNotNil: [self sketchOn: aCanvas].
