setThumbnailHeight
	|  reply |
	(self hasProperty: #alwaysShowThumbnail) ifFalse:
		[^ self inform: 'setting the thumbnail height is only
applicable when you are currently
showing thumbnails.' translated].
	reply _ FillInTheBlank
		request: 'New height for thumbnails? ' translated
		initialAnswer: self heightForThumbnails printString.
	reply isEmpty ifTrue: [^ self].
	reply _ reply asNumber.
	(reply > 0 and: [reply <= 150]) ifFalse:
		[^ self inform: 'Please be reasonable!' translated].
	self setProperty: #heightForThumbnails toValue: reply.
	self updateSubmorphThumbnails