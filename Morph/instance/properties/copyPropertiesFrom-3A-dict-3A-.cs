copyPropertiesFrom: donorMorph dict: dict

	properties _ donorMorph properties copy.
	properties ifNotNil: [
		properties associationsDo: [:ass |
			ass value isMorph ifTrue: [
				ass value owner ifNil: [ass value: (ass
value copyRecordingIn: dict)]]]].
					"note side effecting.  Any un-owned
morph belongs to us."