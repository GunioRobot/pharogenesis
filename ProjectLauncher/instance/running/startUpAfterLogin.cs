startUpAfterLogin
	| scriptName loader isUrl |
	self setupFlaps.
	Preferences readDocumentAtStartup ifTrue: [
		HTTPClient isRunningInBrowser ifTrue:[
			self setupFromParameters.
			scriptName _ self parameterAt: 'src'.
			CodeLoader defaultBaseURL: (self parameterAt: 'Base').
		] ifFalse:[
			scriptName _ (SmalltalkImage current getSystemAttribute: 2) ifNil:[''].
			scriptName isEmpty ifFalse:[
				"figure out if script name is a URL by itself"
				isUrl _ (scriptName asLowercase beginsWith:'http://') or:[
						(scriptName asLowercase beginsWith:'file://') or:[
						(scriptName asLowercase beginsWith:'ftp://')]].
				isUrl ifFalse:[scriptName _ 'file:',scriptName]].
		]. ]
	ifFalse: [ scriptName := '' ].

	scriptName isEmptyOrNil
		ifTrue:[^Preferences eToyFriendly ifTrue: [self currentWorld addGlobalFlaps]].
	loader _ CodeLoader new.
	loader loadSourceFiles: (Array with: scriptName).
	(scriptName asLowercase endsWith: '.pr') 
		ifTrue:[self installProjectFrom: loader]
		ifFalse:[loader installSourceFiles].
