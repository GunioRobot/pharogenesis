maybeReselectClass: aClass selector: aSelector
	"The protocol or limitClass may have changed, so that there is a different categoryList.  Formerly, the given class and selector were selected; if it is possible to do so, reselect them now"

	aClass ifNil: [^ self].
	(currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass)
		ifTrue:
			[self selectSelectorItsNaturalCategory: aSelector]