save
	self pickRepository ifNotNilDo:
		[:ea |
		ea storeVersion: self version]