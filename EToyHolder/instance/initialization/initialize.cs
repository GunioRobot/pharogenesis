initialize
	"Initialize this EToyHolder for a new, empty EToy."

	title _ self defaultTitle.
	playfield _ PasteUpMorph new.
	playfield borderWidth: 4; borderColor: Color green.
	playfield beSticky.
	playfield setNameTo: 'playfield'.
	playfield color: Color transparent.
	playfield changed.

	BookMorph turnOffSoundWhile:
		[scaffoldingBook _ TabbedPaletteComplex new setNameTo: 'Scaffolding'.
		self initializeScaffoldingContentsForFreshEToy].
