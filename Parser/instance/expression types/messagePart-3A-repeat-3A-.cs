messagePart: level repeat: repeat

	| start receiver selector args precedence words keywordStart |
	[receiver _ parseNode.
	(hereType == #keyword and: [level >= 3])
		ifTrue: 
			[start _ self startOfNextToken.
			selector _ WriteStream on: (String new: 32).
			args _ OrderedCollection new.
			words _ OrderedCollection new.
			[hereType == #keyword]
				whileTrue: 
					[keywordStart _ self startOfNextToken + requestorOffset.
					selector nextPutAll: self advance.
					words addLast: (keywordStart to: self endOfLastToken + requestorOffset).
					self primaryExpression ifFalse: [^self expected: 'Argument'].
					self messagePart: 2 repeat: true.
					args addLast: parseNode].
			(Symbol hasInterned: selector contents ifTrue: [ :sym | selector _ sym])
				ifFalse: [ selector _ self correctSelector: selector contents
										wordIntervals: words
										exprInterval: (start to: self endOfLastToken)
										ifAbort: [ ^ self fail ] ].
			precedence _ 3]
		ifFalse: [((hereType == #binary or: [hereType == #verticalBar])
				and: [level >= 2])
				ifTrue: 
					[start _ self startOfNextToken.
					selector _ self advance asOctetString asSymbol.
					self primaryExpression ifFalse: [^self expected: 'Argument'].
					self messagePart: 1 repeat: true.
					args _ Array with: parseNode.
					precedence _ 2]
				ifFalse: [hereType == #word
						ifTrue: 
							[start _ self startOfNextToken.
							selector _ self advance.
							args _ #().
							words _ OrderedCollection with: (start  + requestorOffset to: self endOfLastToken + requestorOffset).
							(Symbol hasInterned: selector ifTrue: [ :sym | selector _ sym])
								ifFalse: [ selector _ self correctSelector: selector
													wordIntervals: words
													exprInterval: (start to: self endOfLastToken)
													ifAbort: [ ^ self fail ] ].
							precedence _ 1]
						ifFalse: [^args notNil]]].
	parseNode _ MessageNode new
				receiver: receiver
				selector: selector
				arguments: args
				precedence: precedence
				from: encoder
				sourceRange: (start to: self endOfLastToken).
	repeat]
		whileTrue: [].
	^true