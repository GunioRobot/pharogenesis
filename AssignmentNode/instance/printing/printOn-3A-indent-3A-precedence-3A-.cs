printOn: aStream indent: level precedence: p

	p < 4
		ifTrue: [aStream nextPutAll: '('.
				self printOn: aStream indent: level.
				aStream nextPutAll: ')']
		ifFalse: [self printOn: aStream indent: level]