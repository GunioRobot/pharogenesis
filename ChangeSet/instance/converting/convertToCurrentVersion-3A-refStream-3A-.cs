convertToCurrentVersion: varDict refStream: smartRefStrm
	
	"major change - 4/4/2000"
	varDict at: 'classChanges' ifPresent: [ :x | 
		self convertApril2000: varDict using: smartRefStrm
	].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.

