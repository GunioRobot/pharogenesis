editScriptTextually
	| newBrowser |
	self becomeTextuallyCoded.
	(newBrowser _ Browser new) setClass: playerScripted class selector: scriptName.
	^ Browser openBrowserView: (newBrowser openMessageEditString: nil)
		label: ('textual script for "', scriptName, '" in ', playerScripted externalName)