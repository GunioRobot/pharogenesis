chooseNewFormForSketchMorph
	"Only available when argument is a SketchMorph"
	| reply |
	reply _ FillInTheBlank request: 'Which element of GIFImports? '.
	reply isEmpty ifTrue: [^ self].
	(GIFImports includesKey: reply) ifFalse: [^ self inform: 'sorry, no such element'].
 
	argument form: (GIFImports at: reply)