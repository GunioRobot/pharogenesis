componentName: aSymbol

	aSymbol = #blue ifTrue: [
		operatorOrExpression _ #setBlueComponentIn:to:.
	].
	aSymbol = #green ifTrue: [
		operatorOrExpression _ #setGreenComponentIn:to:.
	].
	aSymbol = #red ifTrue: [
		operatorOrExpression _ #setRedComponentIn:to:.
	].
	self addPatchTile.

