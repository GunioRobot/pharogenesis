openInstanceBrowserWithTiles
	"Open up an instance browser on me with tiles as the code type, and with the search level as desired."

	| aBrowser |
	aBrowser _ InstanceBrowser new.
	aBrowser useVocabulary: Vocabulary fullVocabulary.
	aBrowser limitClass: self class.
	aBrowser contentsSymbol: #tiles.		"preset it to make extra buttons (tile menus)"
	aBrowser openOnObject: self inWorld: ActiveWorld showingSelector: nil.
	aBrowser contentsSymbol: #source.
	aBrowser toggleShowingTiles.

	"
(2@3) openInstanceBrowserWithTiles.
WatchMorph new openInstanceBrowserWithTiles
"