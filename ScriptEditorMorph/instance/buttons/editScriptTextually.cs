editScriptTextually
	| newBrowser |
	self becomeTextuallyCoded.
	(newBrowser _ Browser new) setClass: playerScripted class selector: scriptName.
	(Preferences valueOfFlag: #editPlayerScriptsInPlace)
		ifTrue:
			[self addTextualScript: newBrowser]
		ifFalse:
			[Browser openBrowserView: (newBrowser openMessageEditString: nil) label: ('textual script for "', scriptName, '" in ', playerScripted externalName)]