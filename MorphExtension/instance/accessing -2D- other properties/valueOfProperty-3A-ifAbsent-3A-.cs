valueOfProperty: aSymbol ifAbsent: aBlock 
	"if the receiver possesses a property of the given name, answer  
	its value. If not then evaluate aBlock and answer the result of  
	this block evaluation"
	self hasOtherProperties
		ifFalse: [^ aBlock value].
	^ self otherProperties
		at: aSymbol
		ifAbsent: [^ aBlock value]