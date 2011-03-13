selectorsMatching
	"Anwer a list of selectors in the receiver that match the current search string"

	| fragment aList |
	fragment := self lastSearchString asLowercase.
	aList := targetClass allSelectors select:
		[:aSelector | (aSelector includesSubstring: fragment caseSensitive: false) and:
			[currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass]].

	^ aList asSortedArray