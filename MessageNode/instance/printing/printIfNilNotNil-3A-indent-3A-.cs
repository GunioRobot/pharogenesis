printIfNilNotNil: aStream indent: level

	receiver ifNotNil:
		[receiver ifNilReceiver printOn: aStream indent: level precedence: precedence].
	(arguments first isJust: NodeNil) ifTrue:
		[^ self printKeywords: #ifNotNil:
				arguments: { arguments second }
				on: aStream indent: level].
	(arguments second isJust: NodeNil) ifTrue:
		[^ self printKeywords: #ifNil:
				arguments: { arguments first }
				on: aStream indent: level].
	^ self printKeywords: #ifNil:ifNotNil:
			arguments: arguments
			on: aStream indent: level