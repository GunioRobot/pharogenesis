updateMenuButtonImage
	"update the receiver's menuButton. put a new image inside"
menuButton isNil ifTrue:[^ self].

	menuButton removeAllMorphs.
	menuButton
		addMorphCentered: (ImageMorph new image: self menuImage)