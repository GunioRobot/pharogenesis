targetScriptDictionary

	| scriptDict |
	target ifNil: [^Dictionary new].
	^target 
		valueOfProperty: #namedCameraScripts 
		ifAbsent: [
			scriptDict _ Dictionary new.
			target setProperty: #namedCameraScripts toValue: scriptDict.
			scriptDict
		].

