addToFormatter: formatter
	| url embeddedMorph |
	self src isNil ifTrue:[^self].
	url _ self src.
	embeddedMorph _ self embeddedMorphFor: url.
	embeddedMorph isNil ifTrue:[^self].
	formatter baseUrl ifNotNil:[url _ url asUrlRelativeTo: formatter baseUrl].
	embeddedMorph extent: self extent.
	embeddedMorph sourceUrl: url.
	embeddedMorph setProperty: #embedded toValue: true.
	formatter addIncompleteMorph: embeddedMorph.