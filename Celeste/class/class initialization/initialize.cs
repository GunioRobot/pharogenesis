initialize
	"Celeste initialize"

	"user preferences"
	DeleteInboxAfterFetching ifNil: [ DeleteInboxAfterFetching _ false ].
	SuppressWorthlessHeaderFields ifNil: [ SuppressWorthlessHeaderFields _ true ].
	UseScaffoldingInterface ifNil: [ UseScaffoldingInterface _ true ].

	"options with no UI; just set their values directly"
	FormatWhenFetching ifNil: [ FormatWhenFetching _ false ].
	self flag: #celeste.  "get rid of this preference, I think!"

	"dictionary of custom filters (obsolete, but left here for transitioning)"
	CustomFilters ifNil: [ CustomFilters _ Dictionary new ].

	"dictionary of named filters"
	NamedFilters ifNil: [ NamedFilters := Dictionary new ].
	NamedFilters isEmpty ifTrue: [
		self addExampleFilters.
		self upgradeCustomFilters ].

	"Add global preferences"
	self addPreferenceForOptionalCelesteStatusPane.
	self addPreferenceForCelesteShowingAttachmentsFlag.
	self addPreferenceForCelesteDespam.

	"add Celeste to the startup/shutdown regime"
	Smalltalk addToStartUpList: self.

	self registerInOpenMenu.
	self registerInFlapsRegistry.