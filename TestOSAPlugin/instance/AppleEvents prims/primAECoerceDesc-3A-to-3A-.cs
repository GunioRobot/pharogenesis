primAECoerceDesc: typeCode to: result

	|rcvr |
	rcvr _ self 	primitive: 	'primAECoerceDesc'
				parameters:	#(DescType AEDesc)
				receiver:	#AEDesc.
	^(self 
		cCode: 'AECoerceDesc(rcvr,*typeCode,result)'
		inSmalltalk: [[rcvr]. -1]) asOop: Unsigned