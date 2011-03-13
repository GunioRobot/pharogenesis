initialize
	"Iniitialize the character dictionary if it doesn't exist yet.  2/5/96 sw"

	CharacterDictionary == nil ifTrue:
		[CharacterDictionary _ Dictionary new]