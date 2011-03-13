browseCardClass
	"Browse the class of the current card"

	| suffix |
	suffix _ self currentCard class name numericSuffix.
	HierarchyBrowser newFor: self currentCard class labeled: 'Background ', suffix asString
