lastErrorNumber
	"Answer the error code number of the last error"

	| aeDesc |
	aeDesc _ AEDesc new.
	Applescript generic 
		primOSAScriptError: (DescType of: 'errn')
		type: (DescType of: 'shor')
		to: aeDesc.
	^aeDesc asShortThenDispose
