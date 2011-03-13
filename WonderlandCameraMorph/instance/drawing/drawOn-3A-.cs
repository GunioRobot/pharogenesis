drawOn: aCanvas 
	| bg |
	bg _ self valueOfProperty: #backgroundSnapshot.
	bg == nil ifFalse:[
		(self bgCacheValid) ifFalse:[
			bg _ Display allocateForm: self extent.
			Display displayOn: bg at: bounds origin negated.
			self setProperty: #backgroundSnapshot toValue: bg.
		].
		aCanvas drawImage: bg at: bounds origin.
	].
	aCanvas asBalloonCanvas render: self.
	self outline ifNotNil: [self sketchOn: aCanvas].
	"*** hack ***"
	pickedPoint _ nil.