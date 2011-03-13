standardHolder
	^ costume ifNil: [nil] ifNotNil:
		[costume presenter ifNil: [nil] ifNotNil: [costume presenter standardHolder]]