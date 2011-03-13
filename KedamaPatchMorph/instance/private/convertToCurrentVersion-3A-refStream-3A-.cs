convertToCurrentVersion: varDict refStream: smartRefStrm
	
	varDict at: 'useLogDisplay' ifPresent: [ :x | 
		displayType _ x ifTrue: [#logScale] ifFalse: [#linear].
	].
	displayType ifNil: [displayType _ #logScale].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.
