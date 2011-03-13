addFillForProjectTarget: aFillStyle
	| fillStyles |
	fillStyles _ self valueOfProperty: #projectTargetFills ifAbsent:[IdentityDictionary new].
	(fillStyles includesKey: aFillStyle) ifTrue:[^self].
	fillStyles at: aFillStyle put: aFillStyle form.
	self setProperty: #projectTargetFills toValue: fillStyles.
	CurrentProjectRefactoring updateProjectFillsIn: self.
	self changed.