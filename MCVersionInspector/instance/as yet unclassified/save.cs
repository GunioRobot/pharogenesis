save
	self pickRepository ifNotNil:
		[:ea |
		ea storeVersion: self version]