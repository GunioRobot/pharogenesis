primAEDisposeDesc
	
	|rcvr|
	rcvr _	self	primitive: 	'primAEDisposeDesc'
				parameters:	#()
				receiver: 	#AEDesc.
	^(self 
		cCode: 'AEDisposeDesc(rcvr)'
		inSmalltalk: [[rcvr]. -1]) asOop: Unsigned