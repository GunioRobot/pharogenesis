scriptingName
"Answer the name of my generic scripting component"

	|aeDesc result |
	aeDesc _ AEDesc new.
	result _ self primOSAScriptingComponentNameTo: aeDesc.
	result isZero ifFalse: [^nil].
	^aeDesc asStringThenDispose.
