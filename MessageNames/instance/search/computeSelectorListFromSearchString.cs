computeSelectorListFromSearchString
	"Compute selector list from search string"
	| raw sorted |
	searchString _ searchString asString copyWithout: $ .
	selectorList _ Cursor wait
				showWhile: [raw _ Symbol selectorsContaining: searchString.
					sorted _ raw as: SortedCollection.
					sorted
						sortBlock: [:x :y | x asLowercase <= y asLowercase].
					sorted asArray].
	selectorList size > 19
		ifFalse: ["else the following filtering is considered too expensive. This 19  
			should be a system-maintained Parameter, someday"
			selectorList _ self systemNavigation allSelectorsWithAnyImplementorsIn: selectorList].
	^ selectorList