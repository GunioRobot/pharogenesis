update: aSelector
	self textSelector ifNotNil: [
		aSelector = self textSelector
			ifTrue: [ | morph |
				(aSelector isSymbol and: [model notNil])
					ifTrue: [
						morph _
							(self model perform: aSelector) asMorph]
					ifFalse: [ morph _ aSelector value asMorph].
				self subMorph: morph]].
	self changed