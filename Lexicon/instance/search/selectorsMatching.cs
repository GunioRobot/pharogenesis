selectorsMatching
	"Anwer a list of selectors in the receiver that match the current search string"

	| fragment aList |
	fragment _ self lastSearchString asLowercase.
	aList _ targetClass allSelectors select:
		[:aSelector | (aSelector includesSubstring: fragment caseSensitive: false) and:
			[currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass]].

	^ aList asSortedArray