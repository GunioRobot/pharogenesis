removeClassVarName: aString 
	"Remove the class variable whose name is the argument, aString, from 
	the names defined in the receiver, a class. Create an error notification if 
	aString is not a class variable or if it is still being used in the code of 
	the class."

	| anAssoc aSymbol |
	aSymbol _ aString asSymbol.
	(classPool includesKey: aSymbol)
		ifFalse: [^self error: aString, ' is not a class variable'].
	anAssoc _ classPool associationAt: aSymbol.
	self withAllSubclasses do:
		[:subclass |
		(Array with: subclass with: subclass class) do:
			[:classOrMeta |
			(classOrMeta whichSelectorsReferTo: (classPool associationAt: aSymbol))
				isEmpty
					ifFalse: [^self error: aString
								, ' is still used in code of class '
								, classOrMeta name]]].
	classPool removeKey: aSymbol