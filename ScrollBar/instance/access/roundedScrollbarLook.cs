roundedScrollbarLook
	"Rounded look currently only shows up in flop-out mode"
	^Preferences alternativeScrollbarLook and: [Preferences inboardScrollbars not and: [self class alwaysShowFlatScrollbarForAlternativeLook not]]
