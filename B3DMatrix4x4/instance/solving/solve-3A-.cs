solve: aVector

	^self clone inplaceHouseHolderTransform: aVector
	"or:
	^self clone inplaceDecomposeLU solveLU: aVector
	"