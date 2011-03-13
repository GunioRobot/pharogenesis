readRecognizerDictionaryFrom: aFileName
	"Read a fresh version of the Recognizer dictionary in from a file of the given name.  7/26/96 sw"
	"CharRecog readRecognizerDictionaryFrom: 'RecogDictionary.2 fixed'"

   | aReferenceStream |
   aReferenceStream _ ReferenceStream fileNamed: aFileName.
   CharacterDictionary _ aReferenceStream next.
   aReferenceStream close.
