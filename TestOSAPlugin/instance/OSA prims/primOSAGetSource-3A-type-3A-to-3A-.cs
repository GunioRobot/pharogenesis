primOSAGetSource: aScriptID type: aDescType to: resultData

	|component|
	component _ self	primitive: 	'primOSAGetSource'
						parameters: #(OSAID DescType AEDesc)
						receiver:	#ComponentInstance.
	
	^(self cCode: 'OSAGetSource(*component,*aScriptID,*aDescType, resultData)'
			inSmalltalk: [[component]. -1]) asOop: Unsigned