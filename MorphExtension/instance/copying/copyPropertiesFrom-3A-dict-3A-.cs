copyPropertiesFrom: donorMorph dict: dict
	| val |
	otherProperties _ donorMorph otherProperties copy.
	otherProperties ifNotNil: [
		otherProperties associationsDo:
			[:assn | val _ assn value.
			val isMorph ifTrue: [
				val owner ifNil: [assn value: (val copyRecordingIn: dict)]]]].
					"note side effecting.  Any un-owned morph belongs to us."