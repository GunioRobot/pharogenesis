initialize
	"Add Process::env if it is missing"
	
	(Process instVarNames includes: 'env')
	ifFalse: [ Process addInstVarName: 'env'].