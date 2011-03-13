errorList: anOrderedCollection

	(errorList = anOrderedCollection)
		ifFalse: [
			errorList := anOrderedCollection.
			self changed: #errorList].