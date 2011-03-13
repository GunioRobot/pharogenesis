componentName: aSymbol

	aSymbol = #blue ifTrue: [
		operatorOrExpression _ #getBlueComponentIn:.
	].
	aSymbol = #green ifTrue: [
		operatorOrExpression _ #getGreenComponentIn:.
	].
	aSymbol = #red ifTrue: [
		operatorOrExpression _ #getRedComponentIn:.
	].
	self addPatchTile.

