convertToCurrentVersion: varDict refStream: smartRefStrm
	"If we're reading in an old version with a system path instance variable, convert it to a vm path."

	varDict at: 'systemPathName' ifPresent: [ :x | 
		vmPathName _ x.
	].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.
