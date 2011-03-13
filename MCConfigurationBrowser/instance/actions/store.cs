store
	(self checkRepositories and: [self checkDependencies]) ifFalse: [^self].
	self pickName ifNotNilDo: [:name |
		self configuration name: name.
		self pickRepository ifNotNilDo: [:repo |
			repo storeVersion: self configuration]].