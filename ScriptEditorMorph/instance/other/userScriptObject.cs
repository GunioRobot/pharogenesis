userScriptObject
	"Answer the user-script object associated with the receiver"

	| aPlayerScripted topEd |
	aPlayerScripted _ (topEd _ self topEditor) playerScripted.
	^ aPlayerScripted class userScriptForPlayer: aPlayerScripted selector: topEd scriptName 