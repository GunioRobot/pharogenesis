printOn: aStream indent: level precedence: p

	(aStream dialect = #SQ00
			ifTrue: [p < 3]
			ifFalse: [p < 4])
		ifTrue: [aStream nextPutAll: '('.
				self printOn: aStream indent: level.
				aStream nextPutAll: ')']
		ifFalse: [self printOn: aStream indent: level]