pattern: fromDoit inContext: ctxt 
	" unarySelector | binarySelector arg | keyword arg {keyword arg} =>  
	{selector, arguments, precedence}."
	| args selector |
	doitFlag _ fromDoit.
	fromDoit ifTrue:
			[ctxt == nil
				ifTrue: [^ {#DoIt. {}. 1}]
				ifFalse: [^ {#DoItIn:. {encoder encodeVariable: 'homeContext'}. 3}]].

	hereType == #word ifTrue: [^ {self advance asSymbol. {}. 1}].

	(hereType == #binary or: [hereType == #verticalBar])
		ifTrue: 
			[selector _ self advance asSymbol.
			args _ Array with: (encoder bindArg: self argumentName).
			^ {selector. args. 2}].

	hereType == #keyword
		ifTrue: 
			[selector _ WriteStream on: (String new: 32).
			args _ OrderedCollection new.
			[hereType == #keyword]
				whileTrue: 
					[selector nextPutAll: self advance.
					args addLast: (encoder bindArg: self argumentName)].
			^ {selector contents asSymbol. args. 3}].

	^ self expected: 'Message pattern'