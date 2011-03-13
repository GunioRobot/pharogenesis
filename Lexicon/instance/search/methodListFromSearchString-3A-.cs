methodListFromSearchString: fragment
	"Answer a method list of methods whose selectors match the given fragment"

	|  aList searchFor |
	currentQueryParameter := fragment.
	currentQuery := #selectorName.
	autoSelectString := fragment.
	searchFor := fragment asString asLowercase withBlanksTrimmed.

	aList := targetClass allSelectors select:
		[:aSelector | currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass].
	searchFor size > 0 ifTrue:
		[aList := aList select:
			[:aSelector | aSelector includesSubstring: searchFor caseSensitive: false]].
	^ aList asSortedArray
