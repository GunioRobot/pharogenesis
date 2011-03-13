newOnCategory: aCategory
	"Browse the system category of the given name.  7/13/96 sw"

	"Browser newOnCategory: 'Interface-Browser'"

	| newBrowser catList |
	newBrowser _ Browser new.
	catList _ newBrowser systemCategoryList.
	newBrowser systemCategoryListIndex: (catList indexOf: aCategory asSymbol ifAbsent: [^ self inform: 'No such category']).
	BrowserView openSystemCategoryBrowser: newBrowser label: aCategory editString: nil