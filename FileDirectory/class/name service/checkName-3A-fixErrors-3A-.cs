checkName: fullName fixErrors: flag
	FileDirectory convertName: fullName
		to: [:directory :fileName | ^ directory checkName: fileName fixErrors: flag]