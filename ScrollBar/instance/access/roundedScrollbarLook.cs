roundedScrollbarLook
	"Rounded look currently only shows up in flop-out mode"
	^false and: [
		self class alwaysShowFlatScrollbarForAlternativeLook not]
