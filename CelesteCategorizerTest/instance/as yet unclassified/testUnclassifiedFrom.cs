testUnclassifiedFrom
	self assert: (categorizer unclassifiedFrom: {1. 2. 3. 4. 5}) asSortedCollection asArray = {1. 2. 3. 4. 5}.
	categorizer file: 3 inCategory: 'pickle'.
	self assert: (categorizer unclassifiedFrom: {1. 2. 3. 4. 5}) asSortedCollection asArray = {1. 2. 4. 5}.
