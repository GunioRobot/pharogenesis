quickList
	"Compute the selectors for the single example of receiver and args, in the very top pane" 

	| data array result resultArray newExp dataStrings |
	data _ contents asString.
	"delete trailing period. This should be fixed in the Parser!"
 	[data last isSeparator] whileTrue: [data _ data allButLast]. 
	data last = $. ifTrue: [data _ data allButLast]. 	"Eval"
	array _ Compiler evaluate: '{', data, '}'. "#( data1 data2 result )"
 	dataStrings _ (Compiler new parse: 'zort ' , data in: Object notifying: nil)
				block statements allButLast collect:
				[:node | String streamContents:
					[:strm | (node isKindOf: MessageNode) ifTrue: [strm nextPut: $(].
					node printOn: strm indent: 0.
					(node isKindOf: MessageNode) ifTrue: [strm nextPut: $)].]].
	array size < 2 ifTrue: [self inform: 'If you are giving an example of receiver, \args, and result, please put periods between the parts.\Otherwise just type one selector fragment' withCRs. ^#()].
 	array _ Array with: array allButLast with: array last. "#( (data1 data2) result )" 
	result _ MethodFinder new load: array; findMessage.
 	resultArray _ self listFromResult: result. 
	resultArray isEmpty ifTrue: [self inform: result].

	dataStrings size = (array first size + 1) ifTrue:
		[resultArray _ resultArray collect: [:expression |
		newExp _ expression.
		array first withIndexDo: [:lit :i |
			newExp _ newExp copyReplaceAll: 'data', i printString
							with: (dataStrings at: i)].
		newExp, ' --> ', dataStrings last]].

 	^ resultArray