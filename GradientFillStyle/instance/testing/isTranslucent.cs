isTranslucent
	^isTranslucent ifNil:[isTranslucent _ self checkTranslucency]