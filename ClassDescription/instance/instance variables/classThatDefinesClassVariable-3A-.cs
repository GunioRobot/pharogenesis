classThatDefinesClassVariable: classVarName
	"Answer the class that defines the given class variable"

	(self classPool includesKey: classVarName asSymbol) ifTrue: [^ self]. 
	^ superclass ifNotNil: [superclass classThatDefinesClassVariable: classVarName]