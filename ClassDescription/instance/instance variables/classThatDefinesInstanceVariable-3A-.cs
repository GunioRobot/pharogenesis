classThatDefinesInstanceVariable: instVarName
	(instanceVariables notNil and: [instanceVariables includes: instVarName asString]) ifTrue: [^ self]. 
	^ superclass ifNotNil: [superclass classThatDefinesInstanceVariable: instVarName]