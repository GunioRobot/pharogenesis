addInstanceVarNamed: aName withValue: aValue
	"Add an instance variable named aName and give it value aValue"

	(Utilities isLegalInstVarName: aName) ifFalse: [^ self break].
	(Utilities inviolateInstanceVariableNames includes:  aName) ifTrue: [^ self break].
	self class addInstVarName: aName asString.
	self instVarAt: self class instSize put: aValue