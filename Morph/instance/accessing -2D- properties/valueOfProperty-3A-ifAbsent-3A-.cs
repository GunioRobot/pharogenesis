valueOfProperty: aSymbol ifAbsent: aBlock 
	"if the receiver possesses a property of the given name, answer  
	its value. If not then evaluate aBlock and answer the result of  
	this block evaluation"
	^ self hasExtension
		ifTrue: [self extension valueOfProperty: aSymbol ifAbsent: aBlock]
		ifFalse: [aBlock value]