isLegalFileName: fullName
	FileDirectory convertName: fullName
		to: [:directory :fileName | ^ directory isLegalFileName: fileName]