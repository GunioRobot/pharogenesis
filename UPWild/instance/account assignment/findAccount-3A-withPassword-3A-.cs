findAccount: username withPassword: password
	| account |
	account _ accounts detect: [ :acc | acc username = username] ifNone: [
		"no such account"
		^nil ].
	
	account password = password ifFalse:[
		"wrong password"
		^nil ].
	
	^account