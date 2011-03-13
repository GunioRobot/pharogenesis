quickList
	"Compute the selectors for the single example of receiver and args, in the very top pane" 

	| data result resultArray newExp dataStrings mf dataObjects aa |
	data _ contents asString.
	"delete trailing period. This should be fixed in the Parser!"
 	[data last isSeparator] whileTrue: [data _ data allButLast]. 
	data last = $. ifTrue: [data _ data allButLast]. 	"Eval"
	mf _ MethodFinder new.
	data _ mf cleanInputs: data.	"remove common mistakes"
	dataObjects _ Compiler evaluate: '{', data, '}'. "#( data1 data2 result )"
 	dataStrings _ (Compiler new parse: 'zort ' , data in: Object notifying: nil)
				block statements allButLast collect:
				[:node | String streamContents:
					[:strm | (node isKindOf: MessageNode) ifTrue: [strm nextPut: $(].
					node printOn: strm indent: 0.
					(node isKindOf: MessageNode) ifTrue: [strm nextPut: $)].]].
	dataObjects size < 2 ifTrue: [self inform: 'If you are giving an example of receiver, \args, and result, please put periods between the parts.\Otherwise just type one selector fragment' withCRs. ^#()].
 	dataObjects _ Array with: dataObjects allButLast with: dataObjects last. "#( (data1 data2) result )" 
	result _ mf load: dataObjects; findMessage.
	(result first beginsWith: 'no single method') ifFalse: [
		aa _ self testObjects: dataObjects strings: dataStrings.
		dataObjects _ aa second.  dataStrings _ aa third].
	resultArray _ self listFromResult: result. 
	resultArray isEmpty ifTrue: [self inform: result first].

	dataStrings size = (dataObjects first size + 1) ifTrue:
		[resultArray _ resultArray collect: [:expression |
		newExp _ expression.
		dataObjects first withIndexDo: [:lit :i |
			newExp _ newExp copyReplaceAll: 'data', i printString
							with: (dataStrings at: i)].
		newExp, ' --> ', dataStrings last]].

 	^ resultArray