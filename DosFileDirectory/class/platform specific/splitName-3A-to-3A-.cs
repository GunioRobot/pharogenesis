splitName: fullName to: pathAndNameBlock
	(self isDrive: fullName)
		ifTrue: [^ pathAndNameBlock value: fullName value: ''].
	^ super splitName: fullName to: pathAndNameBlock