copyWithTempsFromMethodNode: aMethodNode
	^self copyWithTrailerBytes: (self qCompress: aMethodNode schematicTempNamesString)