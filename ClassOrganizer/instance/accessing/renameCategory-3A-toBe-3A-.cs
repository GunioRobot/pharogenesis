renameCategory: oldCatString toBe: newCatString
	| oldCat newCat oldElementsBefore oldElementsAfter |
	oldCat _ oldCatString asSymbol.
	newCat _ newCatString asSymbol.
	oldElementsBefore _ self listAtCategoryNamed: oldCat.
	SystemChangeNotifier uniqueInstance doSilently: [
		super renameCategory: oldCatString toBe: newCatString].
	oldElementsAfter _ (self listAtCategoryNamed: oldCat) asSet.
	oldElementsBefore do: [:each |
		(oldElementsAfter includes: each)
			ifFalse: [self notifyOfChangedSelector: each from: oldCat to: newCat].
	].
	self notifyOfChangedCategoryFrom: oldCat to: newCat.