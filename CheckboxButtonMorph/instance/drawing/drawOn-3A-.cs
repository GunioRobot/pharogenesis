drawOn: aCanvas
	"Draw the image for the current state."
	
	|img|
	aCanvas fillRectangle: self bounds fillStyle: self fillStyle borderStyle: self borderStyle.
	img := self imageToUse.
	img ifNotNil: [
		aCanvas
			translucentImage: img
			at: self innerBounds center - (img extent // 2)].
	(self state == #pressed or: [self state == #repressed]) ifTrue: [
		aCanvas fillRectangle: self innerBounds fillStyle: (self paneColor alpha: 0.3)].
	self enabled ifFalse: [aCanvas fillRectangle: self innerBounds fillStyle: (self paneColor alpha: 0.4)]