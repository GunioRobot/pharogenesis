primOSAExecute: script in: context mode: mode to: result

	<primitive: 'primOSAExecute' module: 'TestOSAPlugin'>
	^TestOSAPlugin 
		doPrimitive: 'primOSAExecute:in:mode:to:'
		withArguments: { script. context. mode. result }