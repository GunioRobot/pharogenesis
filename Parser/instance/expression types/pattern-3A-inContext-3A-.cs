pattern: fromDoit inContext: ctxt
	" unarySelector | binarySelector arg | keyword arg {keyword arg} =>
	{selector, arguments, precedence}."
	| args selector |
	doitFlag := fromDoit.
	fromDoit ifTrue:
		[^ctxt == nil
			ifTrue: [{#DoIt. {}. 1}]
			ifFalse: [{#DoItIn:. {encoder encodeVariable: encoder doItInContextName}. 3}]].

	hereType == #word ifTrue: [^ {self advance asSymbol. {}. 1}].

	(hereType == #binary or: [hereType == #verticalBar]) ifTrue: 
		[selector := self advance asSymbol.
		args := Array with: (encoder bindArg: self argumentName).
		^ {selector. args. 2}].

	hereType == #keyword ifTrue: 
		[selector := (String new: 32) writeStream.
		args := OrderedCollection new.
		[hereType == #keyword] whileTrue:[
			selector nextPutAll: self advance.
			args addLast: (encoder bindArg: self argumentName).
		].
		^ {selector contents asSymbol. args. 3}].
	hereType == #positionalMessage ifTrue:[
		args := OrderedCollection new.
		selector := self advance.
		hereType == #rightParenthesis ifTrue:[self advance. ^{(selector,'/0') asSymbol. args. 1}].
		[
			args addLast: (encoder bindArg: self argumentName).
			hereType == #rightParenthesis ifTrue:[
				self advance. 
				selector := (selector,'/', args size printString) asSymbol.
				^{selector. args. 1}].
			here == #, ifFalse:[self expected: 'comma'].
			self advance.
		] repeat.
	].
	^self expected: 'Message pattern'