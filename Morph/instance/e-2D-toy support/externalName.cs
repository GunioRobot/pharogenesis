externalName
	| aName aHolder |
	(aName _ self knownName) ifNotNil: [^ aName].
	^ (aHolder _ self standardHolder)
		ifNil:
			[self innocuousName]
		ifNotNil:
			[aName _ aHolder chooseExternalNameFor: self.
			self setNamePropertyTo: aName.
			aName]
