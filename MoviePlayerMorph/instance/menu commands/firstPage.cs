firstPage
	playDirection = 0 ifFalse: [^ self]. "No-op during play"
	self goToPage: 1
