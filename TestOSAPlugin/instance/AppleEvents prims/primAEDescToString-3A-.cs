primAEDescToString: aString

	| rcvr size |
	rcvr _ self	primitive: 	'primAEDescToString'
				parameters: #(String)
				receiver: #AEDesc.
	size _ aString size.
	self cCode: 'BlockMove(*(rcvr->dataHandle), aString, size)'
		 inSmalltalk: [rcvr. size].
	^aString asOop: String

