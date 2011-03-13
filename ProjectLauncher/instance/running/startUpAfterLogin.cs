startUpAfterLogin
	| scriptName loader isUrl |
	Preferences readDocumentAtStartup ifTrue: [
		HTTPClient isRunningInBrowser ifTrue:[
			self setupFromParameters.
			scriptName := self parameterAt: 'src'.
			CodeLoader defaultBaseURL: (self parameterAt: 'Base').
		] ifFalse:[
			scriptName := (SmalltalkImage current getSystemAttribute: 2) ifNil:[''].
			scriptName := scriptName convertFromSystemString.
			scriptName isEmpty ifFalse:[
				"figure out if script name is a URL by itself"
				isUrl := (scriptName asLowercase beginsWith:'http://') or:[
						(scriptName asLowercase beginsWith:'file://') or:[
						(scriptName asLowercase beginsWith:'ftp://')]].
				isUrl ifFalse:[scriptName := 'file:',scriptName]].
		]. ]
	ifFalse: [ scriptName := '' ].

	scriptName isEmptyOrNil
		ifTrue:[^ self].
	loader := CodeLoader new.
	loader loadSourceFiles: (Array with: scriptName).
	loader installSourceFiles.