addFillForProjectTarget: aFillStyle
	| fillStyles |
	fillStyles := self valueOfProperty: #projectTargetFills ifAbsent:[IdentityDictionary new].
	(fillStyles includesKey: aFillStyle) ifTrue:[^self].
	fillStyles at: aFillStyle put: aFillStyle form.
	self setProperty: #projectTargetFills toValue: fillStyles.
	self updateProjectFillsFrom: Project current.
	self changed.