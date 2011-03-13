container: aContainer 
	"Answer an instance of me whose model is aContainer. Give it a 2-dot 
	border."

	| aCodeView |
	aCodeView _ self new model: aContainer.
	aCodeView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	^aCodeView