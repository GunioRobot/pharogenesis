conversionMethodsFor: classList
	| oldStruct newStruct list |
	"Each of these needs a conversion method.  Hard part is the comment in it.  Return a MessageSet."

	list _ OrderedCollection new.
	classList do: [:cls |
		oldStruct _ structures at: cls name ifAbsent: [#()].
		newStruct _ (Array with: cls classVersion), (cls allInstVarNames).
		self writeConversionMethodIn: cls fromInstVars: oldStruct to: newStruct 
				renamedFrom: nil.
		list add: cls name, ' convertToCurrentVersion:refStream:'.
		].

	^list.