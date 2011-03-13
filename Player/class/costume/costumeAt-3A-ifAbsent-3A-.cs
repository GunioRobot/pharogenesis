costumeAt: aCostumeName ifAbsent: aBlock
	costumeDictionary ifNil: [^ aBlock value].
	^ costumeDictionary at: aCostumeName ifAbsent: [aBlock value]