primOSAScriptError: selector type: type to: result

	|component|
	component _ self primitive: 	'primOSAScriptError'
					parameters: #(DescType DescType AEDesc)
					receiver:	#ComponentInstance.

	^(self cCode: 'OSAScriptError(*component,*selector,*type,result)'
			inSmalltalk: [[component]. -1]) asOop: Unsigned