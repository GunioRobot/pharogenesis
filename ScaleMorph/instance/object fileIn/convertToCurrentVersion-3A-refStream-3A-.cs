convertToCurrentVersion: varDict refStream: smartRefStrm
	
	labelsAbove ifNil: [labelsAbove _ true].
	captionAbove ifNil: [captionAbove _ true].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.
