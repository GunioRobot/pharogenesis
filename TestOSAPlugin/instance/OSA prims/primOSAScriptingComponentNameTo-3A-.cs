primOSAScriptingComponentNameTo: anAEDesc

	|component|
	component _ self	primitive: 	'primOSAScriptingComponentName'
						parameters: #(AEDesc)
						receiver:	#ComponentInstance.
	
	^(self cCode: 'OSAScriptingComponentName(*component,anAEDesc)'
			inSmalltalk: [[component]. -1]) asOop: Unsigned