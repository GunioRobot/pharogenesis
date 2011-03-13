copyWithExclusionOf: aSymbol to: aTrait
	| composition transformation |
	composition _ self copyTraitExpression.
	transformation _ (composition transformationOfTrait: aTrait).
	^composition
		remove: transformation;
		add: (transformation addExclusionOf: aSymbol);
		yourself