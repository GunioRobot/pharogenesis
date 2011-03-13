failureList: anOrderedCollection

	(failureList = anOrderedCollection)
		ifFalse: [
			failureList := anOrderedCollection.
			self changed: #failureList].