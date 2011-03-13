fieldList
	fieldList ifNotNil: [^ fieldList].
	^ (fieldList _ super fieldList)