initializeStandardVocabularies
	"Initialize a few standard vocabularies and place them in the AllStandardVocabularies list."

	AllStandardVocabularies _ nil.

	
self addStandardVocabulary: EToyVocabulary new.
	self addStandardVocabulary: EToyVectorVocabulary new.

	self addStandardVocabulary: self newPublicVocabulary.
	self addStandardVocabulary: FullVocabulary new.

	self addStandardVocabulary: self newQuadVocabulary.

	self addStandardVocabulary: ColorType new.
	self addStandardVocabulary: BooleanType new.
	self addStandardVocabulary: GraphicType new.
	self addStandardVocabulary: PlayerType new.
	self addStandardVocabulary: SoundType new.
	self addStandardVocabulary: StringType new.
	self addStandardVocabulary: MenuType new.
	self addStandardVocabulary: UnknownType new.
	self addStandardVocabulary: ScriptNameType new.

	self addStandardVocabulary: (SymbolListType new symbols: #(simple raised inset complexFramed complexRaised complexInset complexAltFramed complexAltRaised complexAltInset); vocabularyName: #BorderStyle; yourself).
	self addStandardVocabulary: (SymbolListType new symbols: #(lines arrows arrowheads dots); vocabularyName: #TrailStyle; yourself).
	self addStandardVocabulary: (SymbolListType new symbols: #(leftToRight rightToLeft topToBottom bottomToTop); vocabularyName: #ListDirection; yourself).

	self addStandardVocabulary: (SymbolListType new symbols: #(topLeft bottomRight center justified); vocabularyName: #ListCentering; yourself).

	self addStandardVocabulary: (SymbolListType new symbols: #(buttonDown whilePressed buttonUp); vocabularyName: #ButtonPhase; yourself).

	self addStandardVocabulary: (SymbolListType new symbols: #(rotate #'do not rotate' #'flip left right' #'flip up down'); vocabularyName: #RotationStyle; yourself).

	self addStandardVocabulary: (SymbolListType new symbols: #(rigid spaceFill shrinkWrap); vocabularyName: #Resizing; yourself).

	self addStandardVocabulary: self newSystemVocabulary.  "A custom vocabulary for Smalltalk -- still under development)"

	self numberVocabulary.  		"creates and adds it"
	self wonderlandVocabulary.  	"creates and adds it"
	self vocabularyForClass: Time.   "creates and adds it"

	"Vocabulary initialize"