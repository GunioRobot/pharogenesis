copyRecordingIn: dict
	"Overridden to copy lastAcceptedScript as well."

	| new |
	new _ super copyRecordingIn: dict.
	lastAcceptedScript ifNotNil: [
		new lastAcceptedScript: 
			((dict includesKey: lastAcceptedScript)
				ifTrue: [dict at: lastAcceptedScript]
				ifFalse: [lastAcceptedScript copyRecordingIn: dict])].
	lastScriptEditor ifNotNil: [
		new lastScriptEditor: 
			((dict includesKey: lastScriptEditor)
				ifTrue: [dict at: lastScriptEditor]
				ifFalse: [lastScriptEditor copyRecordingIn: dict])].
	^ new
