printIfOn: aStream indent: level

	aStream dialect = #SQ00 ifTrue:
		["Convert to if-then-else"
		(arguments last isJust: NodeNil) ifTrue:
			[aStream withStyleFor: #prefixKeyword do: [aStream nextPutAll: 'Test '].
			self printParenReceiver: receiver on: aStream indent: level + 1.
			^ self printKeywords: #Yes: arguments: (Array with: arguments first)
						on: aStream indent: level prefix: true].
		(arguments last isJust: NodeFalse) ifTrue:
			[self printReceiver: receiver on: aStream indent: level.
			^ self printKeywords: #and: arguments: (Array with: arguments first)
						on: aStream indent: level].
		(arguments first isJust: NodeNil) ifTrue:
			[aStream withStyleFor: #prefixKeyword do: [aStream nextPutAll: 'Test '].
			self printParenReceiver: receiver on: aStream indent: level + 1.
			^ self printKeywords: #No: arguments: (Array with: arguments last)
						on: aStream indent: level prefix: true].
		(arguments first isJust: NodeTrue) ifTrue:
			[self printReceiver: receiver on: aStream indent: level.
			^ self printKeywords: #or: arguments: (Array with: arguments last)
						on: aStream indent: level].
		aStream withStyleFor: #prefixKeyword do: [aStream nextPutAll: 'Test '].
		self printParenReceiver: receiver on: aStream indent: level + 1.
		^ self printKeywords: #Yes:No: arguments: arguments
						on: aStream indent: level prefix: true].

	receiver ifNotNil: [
		receiver printOn: aStream indent: level + 1 precedence: precedence.
	].
	(arguments last isJust: NodeNil) ifTrue:
		[^ self printKeywords: #ifTrue: arguments: (Array with: arguments first)
					on: aStream indent: level].
	(arguments last isJust: NodeFalse) ifTrue:
		[^ self printKeywords: #and: arguments: (Array with: arguments first)
					on: aStream indent: level].
	(arguments first isJust: NodeNil) ifTrue:
		[^ self printKeywords: #ifFalse: arguments: (Array with: arguments last)
					on: aStream indent: level].
	(arguments first isJust: NodeTrue) ifTrue:
		[^ self printKeywords: #or: arguments: (Array with: arguments last)
					on: aStream indent: level].
	self printKeywords: #ifTrue:ifFalse: arguments: arguments
					on: aStream indent: level