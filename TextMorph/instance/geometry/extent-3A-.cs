extent: aPoint 
	self releaseParagraph.  "invalidate the paragraph cache"
	super extent: (aPoint truncated max: 9@(textStyle lineGrid+2)).
	self fit