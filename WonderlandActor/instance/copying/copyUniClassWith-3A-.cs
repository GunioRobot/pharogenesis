copyUniClassWith: deepCopier
	"my class is a subclass of WonderlandActor.  Return another class just like my class."
	| newCls |
	newCls _ self class officialClass 
		newUniqueClassInstVars: self class instanceVariablesString 
		classInstVars: self class class instanceVariablesString.
	newCls copyMethodDictionaryFrom: self class.
	newCls class copyMethodDictionaryFrom: self class class.
	newCls copyAddedStateFrom: self class.  "All class inst vars, if any"
	^ newCls
