primOSADoScript: source in: context mode: mode resultType: type to: result

	|component|
	component _ self primitive: 	'primOSADoScript'
					parameters: #(AEDesc OSAID SmallInteger DescType AEDesc)
					receiver:	#ComponentInstance.

	^(self cCode: 'OSADoScript(*component,source,*context,*type,mode,result)'
			inSmalltalk: [[component]. -1]) asOop: Unsigned