packageSnapshot
	^ packageSnapshot ifNil: [packageSnapshot _ version package snapshot]