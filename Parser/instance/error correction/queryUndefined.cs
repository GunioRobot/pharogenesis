queryUndefined
	| varStart varName | 
	varName _ parseNode key.
	varStart _ self endOfLastToken + requestorOffset - varName size + 1.
	requestor selectFrom: varStart to: varStart + varName size - 1; select.
	((UIManager default 
		chooseFrom: #('yes' 'no') 
		title: ((varName , ' appears to be\undefined at this point.Proceed anyway?') 
				withCRs asText makeBoldFrom: 1 to: varName size))
		= 1) ifFalse: [^ self fail]