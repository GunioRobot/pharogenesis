setExtent: aPoint  "DisplayScreen startUp"
	width _ aPoint x.
	height _ aPoint y.
	clippingBox _ nil.
	self bitsSize.  "Cause any errors before unrecoverable"
	bits _ nil.  "Free up old bitmap in case space is low"
	bits _ Bitmap new: self bitsSize.
	self boundingBox