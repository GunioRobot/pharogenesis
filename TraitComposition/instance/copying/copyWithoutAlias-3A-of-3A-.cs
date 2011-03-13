copyWithoutAlias: aSymbol of: aTrait
	| composition transformation |
	composition _ self copyTraitExpression.
	transformation _ (composition transformationOfTrait: aTrait).
	^composition
		remove: transformation;
		add: (transformation removeAlias: aSymbol);
		normalizeTransformations;
		yourself