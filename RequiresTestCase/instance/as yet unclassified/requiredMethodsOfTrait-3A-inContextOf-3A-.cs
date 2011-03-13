requiredMethodsOfTrait: basicTrait inContextOf: composedTrait 
	| interestingSelectors sss |
	interestingSelectors := (composedTrait traitComposition 
				transformationOfTrait: basicTrait) allSelectors.
	sss := composedTrait selfSentSelectorsFromSelectors: interestingSelectors.
	^sss copyWithoutAll: composedTrait allSelectors