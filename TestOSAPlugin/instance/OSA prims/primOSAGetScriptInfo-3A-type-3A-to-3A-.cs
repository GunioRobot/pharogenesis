primOSAGetScriptInfo: aScriptID type: aDescType to: resultData

	|component|
	component _ self	primitive: 	'primOSAGetScriptInfo'
						parameters: #(OSAID DescType IntegerArray)
						receiver:	#ComponentInstance.
	
	^(self cCode: 'OSAGetScriptInfo(*component,*aScriptID,*aDescType, (long *)resultData)'
			inSmalltalk: [[component]. -1]) asOop: Unsigned