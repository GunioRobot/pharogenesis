primAEGetKeyPtr: key type: type actual: ignoreDesc to: bytes

	| rcvr size ignoreSize |
	self var: #ignoreSize declareC: 'Size ignoreSize'.
	rcvr _ self	primitive: 	'primAEGetKeyPtr'
				parameters: #(DescType DescType DescType ByteArray)
				receiver: #AEDesc.
	size _ ignoreSize _ bytes size.
	^(self cCode: 'AEGetKeyPtr(rcvr, *key, *type, ignoreDesc, bytes, size, &ignoreSize)'
		 inSmalltalk: [[rcvr. size. ignoreSize]. -1]) asOop: Unsigned