updateRequires
	| sss aTrait |
	sss := self selfSentSelectorsInTrait: aTrait.
	^sss copyWithoutAll: aTrait allSelectors.