methodListFromSearchString: fragment
	"Answer a method list of methods whose selectors match the given fragment"

	|  aList searchFor |
	currentQueryParameter _ fragment.
	currentQuery _ #selectorName.
	autoSelectString _ fragment.
	searchFor _ fragment asString asLowercase withBlanksTrimmed.

	aList _ targetClass allSelectors select:
		[:aSelector | currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass].
	searchFor size > 0 ifTrue:
		[aList _ aList select:
			[:aSelector | aSelector includesSubstring: searchFor caseSensitive: false]].
	^ aList asSortedArray
