localNameFor: fullName
	^ FileDirectory splitName: fullName
		to: [:vol :local | ^ local]