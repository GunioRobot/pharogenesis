descriptionForParameter: aSymbol
	^ (self parameterData detect: [ :one | one first = aSymbol]) at: 4