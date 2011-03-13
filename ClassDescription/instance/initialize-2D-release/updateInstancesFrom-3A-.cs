updateInstancesFrom: oldClass 
	"Recreate any existing instances of the argument, oldClass, as instances of 
	the receiver, which is a newly changed class. Permute variables as 
	necessary."

	| oldInstVarNames map variable old new instSize offset fieldName oldInstances |
	oldClass someInstance == nil ifTrue: [^self].
	"no instances to convert"
	oldInstVarNames _ oldClass allInstVarNames.
	map _ 
		self allInstVarNames 
			collect: [:instVarName | oldInstVarNames indexOf: instVarName].
	variable _ self isVariable.
	instSize _ self instSize.

	"Now perform a bulk mutation of old instances into new ones"
	oldInstances _ oldClass allInstances asArray.
	oldInstances elementsExchangeIdentityWith:
		(oldInstances collect: 
		[:old | 
		variable
			ifTrue: [new _ self basicNew: old basicSize]
			ifFalse: [new _ self basicNew].
		1 to: instSize do: 
			[:offset |  (map at: offset) > 0 ifTrue:
				[new instVarAt: offset
						put: (old instVarAt: (map at: offset))]].
		variable 
			ifTrue: [1 to: old basicSize do: 
						[:offset |
						new basicAt: offset put: (old basicAt: offset)]].
		new])