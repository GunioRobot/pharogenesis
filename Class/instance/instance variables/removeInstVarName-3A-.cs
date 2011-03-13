removeInstVarName: aString 
	"Remove the argument, aString, as one of the receiver's instance variables."

	| newInstVarString |
	(self instVarNames includes: aString)
		ifFalse: [self error: aString , ' is not one of my instance variables'].
	newInstVarString _ ''.
	(self instVarNames copyWithout: aString) do: 
		[:varName | newInstVarString _ newInstVarString , ' ' , varName].
	^(ClassBuilder new)
		name: self name
		inEnvironment: self environment
		subclassOf: self superclass
		type: self typeOfClass
		instanceVariableNames: newInstVarString
		classVariableNames: self classVariablesString
		poolDictionaries: self sharedPoolsString
		category: self category