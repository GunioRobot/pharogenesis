color: aColor

	color _ aColor.
	self submorphsDo: [:m | m color: aColor]