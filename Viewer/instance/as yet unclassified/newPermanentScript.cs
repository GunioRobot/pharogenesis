newPermanentScript
	| aMorph |
	self scriptedPlayer assureUniClass.
	aMorph _ ImageMorph new image: (ScriptingSystem formAtKey: 'newScript').
	aMorph setProperty: #newPermanentScript toValue: true.
	aMorph setProperty: #player toValue: self scriptedPlayer.
	self primaryHand attachMorph: aMorph