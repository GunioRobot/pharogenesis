printWhileOn: aStream indent: level

	aStream dialect = #SQ00
		ifTrue: ["Add prefix keyword"
				aStream withStyleFor: #prefixKeyword
						do: [aStream nextPutAll: (selector key == #whileTrue:
									ifTrue: ['While '] ifFalse: ['Until '])].
				self printParenReceiver: receiver on: aStream indent: level + 1.
				self printKeywords: #do: arguments: arguments
					on: aStream indent: level prefix: true]
		ifFalse: [self printReceiver: receiver on: aStream indent: level.
				(arguments isEmpty not and: [ arguments first isJust: NodeNil]) ifTrue:
						[selector _ SelectorNode new
								key: (selector key == #whileTrue:
									ifTrue: [#whileTrue] ifFalse: [#whileFalse])
								code: #macro.
						arguments _ Array new].
				self printKeywords: selector key arguments: arguments
					on: aStream indent: level]