declareCVarsIn: aCCodeGenerator

	aCCodeGenerator var: 'opcodeTable'
		declareC: 'int opcodeTable[', (OpcodeTableSize + 1) printString, ']'.

	aCCodeGenerator var: 'shortSendTable'			declareC: 'int shortSendTable[4]'.
	aCCodeGenerator var: 'extendedSendTable'		declareC: 'int extendedSendTable[4]'.
	aCCodeGenerator var: 'doubleExtendedSendTable'	declareC: 'int doubleExtendedSendTable[4]'.