deletePrivateGraphics: nameList afterStoringToFileNamed: aFileName
	"This method is used to strip private graphics from the FormDictionary and store them on a file of the given name"

	|  replacement toRemove aReferenceStream keySymbol |
	toRemove _ Dictionary new.
	replacement _ FormDictionary formAtKey: #Gets.

	nameList do:
		[:aKey |
			keySymbol _ aKey asSymbol.
			(toRemove at: keySymbol put: (self formAtKey: keySymbol)).
			FormDictionary at: keySymbol put: replacement].

	aReferenceStream _ ReferenceStream fileNamed: aFileName.
	aReferenceStream nextPut: toRemove.
	aReferenceStream close