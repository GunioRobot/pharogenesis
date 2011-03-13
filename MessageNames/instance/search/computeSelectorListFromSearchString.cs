computeSelectorListFromSearchString
	"Compute selector list from search string"
	| raw sorted |
	searchString := searchString asString copyWithout: $ .
	selectorList := Cursor wait
				showWhile: [raw := Symbol selectorsContaining: searchString.
					sorted := raw as: SortedCollection.
					sorted
						sortBlock: [:x :y | x asLowercase <= y asLowercase].
					sorted asArray].
	selectorList size > 19
		ifFalse: ["else the following filtering is considered too expensive. This 19  
			should be a system-maintained Parameter, someday"
			selectorList := self systemNavigation allSelectorsWithAnyImplementorsIn: selectorList].
	^ selectorList