primOSAExecute: script in: context mode: mode to: result

	|component|
	component _ self primitive: 	'primOSAExecute'
					parameters: #(OSAID OSAID SmallInteger OSAID)
					receiver:	#ComponentInstance.

	^(self cCode: 'OSAExecute(*component,*script,*context,mode,result)'
			inSmalltalk: [[component]. -1]) asOop: Unsigned