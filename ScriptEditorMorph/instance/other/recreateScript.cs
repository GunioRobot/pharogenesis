recreateScript
	| aUserScript |
	aUserScript _ playerScripted class userScriptForPlayer: playerScripted selector: scriptName.
	aUserScript recreateScriptFrom: self