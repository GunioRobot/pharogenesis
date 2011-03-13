printOn: aStream indent: level

	| leadingKeyword |

"may not need this check anymore - may be fixed by the #receiver: change"
	special ifNil: [^aStream nextPutAll: '** MessageNode with nil special **'].


	(special > 0)
		ifTrue: [self perform: self macroPrinter with: aStream with: level]
		ifFalse: [selector key first = $:
				ifTrue: [leadingKeyword _ selector key keywords first.
						aStream nextPutAll: leadingKeyword; space.
						self printReceiver: receiver on: aStream indent: level.
						self printKeywords: (selector key allButFirst: leadingKeyword size + 1) arguments: arguments
							on: aStream indent: level]
				ifFalse: [self printReceiver: receiver on: aStream indent: level.
						self printKeywords: selector key arguments: arguments
						on: aStream indent: level]]