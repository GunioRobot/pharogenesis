isTranslucent
	^isTranslucent ifNil:[isTranslucent := self checkTranslucency]