newEmptyScript
	| aMorph |
	aMorph _ ImageMorph new image: (ScriptingSystem formAtKey: 'newScript').
	aMorph setProperty: #newAnonymousScript toValue: true.
	aMorph setProperty: #player toValue: self scriptedPlayer.
	self primaryHand attachMorph: aMorph