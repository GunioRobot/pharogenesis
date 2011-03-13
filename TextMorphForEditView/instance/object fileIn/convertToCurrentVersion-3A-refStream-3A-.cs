convertToCurrentVersion: varDict refStream: smartRefStrm
	
	acceptOnCR ifNil: [acceptOnCR _ false].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

