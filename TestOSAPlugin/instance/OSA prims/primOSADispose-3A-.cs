primOSADispose: anOSAID

	|component|
	component _ self primitive: 	'primOSADispose'
					parameters: #(OSAID)
					receiver:	#ComponentInstance.

	^(self cCode: 'OSADispose(*component,*anOSAID)'
			inSmalltalk: [[component]. -1]) asOop: Unsigned