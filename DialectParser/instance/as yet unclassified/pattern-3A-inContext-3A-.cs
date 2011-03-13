pattern: fromDoit inContext: ctxt 
	" unarySelector | binarySelector arg | keyword arg {keyword arg} =>  
	{selector, arguments, precedence}."
	| args selector checkpoint |
	doitFlag _ fromDoit.
	fromDoit ifTrue:
			[ctxt == nil
				ifTrue: [^ {#DoIt. {}. 1}]
				ifFalse: [^ {#DoItIn:. {encoder encodeVariable: 'homeContext'}. 3}]].

	"NOTE: there is now an ambiguity between
	keywordSelector (argName) -and- unarySelector (first expression).
	Also, there is an amibuity (if there are no temp declarations) between
	keywordSelector (argName) -and- PrefixKeyword (some expression).
	We use duct tape for now."
	(hereType == #word and: [tokenType == #leftParenthesis]) ifTrue:
		[checkpoint _ self checkpoint.  "in case we have to back out"
		selector _ WriteStream on: (String new: 32).
			args _ OrderedCollection new.
			[hereType == #word
				and: [tokenType == #leftParenthesis
				and: [here first isLowercase
						or: [(#('Test' 'Repeat' 'Answer') includes: here) not]]]]
				whileTrue: 
					[selector nextPutAll: self advance , ':'.  "selector part"
					self advance.  "open paren"
					(args size = 0 and: [tokenType ~~ #rightParenthesis]) ifTrue:
						["This is really a unary selector on a method that
						begins with a parenthesized expression.  Back out now"
						self revertToCheckpoint: checkpoint.
						^ {self advance asSymbol. {}. 1}].
					args addLast: (encoder bindArg: self argumentName).
			(self match: #rightParenthesis)
						ifFalse: [^ self expected: 'right parenthesis']].
			^ {selector contents asSymbol. args. 3}].

	hereType == #word ifTrue: [^ {self advance asSymbol. {}. 1}].

	(hereType == #binary or: [hereType == #verticalBar])
		ifTrue: 
			[selector _ self advance asSymbol.
			args _ Array with: (encoder bindArg: self argumentName).
			^ {selector. args. 2}].

	^ self expected: 'Message pattern'