saveRecognizerDictionaryTo: aFileName
	"Save the current state of the Recognizer dictionary to disk.  7/26/96 sw"

   | aReferenceStream |
aReferenceStream _ ReferenceStream fileNamed: aFileName.
   aReferenceStream nextPut: CharacterDictionary.
   aReferenceStream close