displayCostume: aSymbol

	self currentLook == aSymbol ifTrue: [^true].
	self stateCostumes at: aSymbol ifPresent: [ :aForm |
		currentLook _ aSymbol.
		visibleMorph wearCostume: aForm.
		^true
	].
	^false
