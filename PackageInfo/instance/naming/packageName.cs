packageName
	^ packageName ifNil: [packageName := self categoryName]