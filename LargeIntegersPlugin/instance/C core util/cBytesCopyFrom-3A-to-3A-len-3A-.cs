cBytesCopyFrom: pFrom to: pTo len: len 
	| limit |
	self returnTypeC: 'int'.
	self var: #pFrom declareC: 'unsigned char * pFrom'.
	self var: #pTo declareC: 'unsigned char * pTo'.
	self var: #len declareC: 'int len'.
	self var: #limit declareC: 'int limit'.

	self cCode: '' inSmalltalk: [
		(interpreterProxy isKindOf: InterpreterSimulator) ifTrue: [
			"called from InterpreterSimulator"
				limit _ len - 1.
				0 to: limit do: [:i |
					interpreterProxy byteAt: pTo + i
						put: (interpreterProxy byteAt: pFrom + i)
				].
			^ 0
		].
	].	
	limit _ len - 1.
	0 to: limit do: [:i | pTo at: i put: (pFrom at: i)].
	^ 0