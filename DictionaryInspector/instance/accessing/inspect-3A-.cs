inspect: aDictionary
	"Initialize the receiver so that it is inspecting aDictionary. There is no 
	current selection."

	self initialize.
	(aDictionary isKindOf: Dictionary) ifFalse:
		[^ self error: 'DictionaryInspectors can only inspect dictionaries' ].
	object _ aDictionary.
	contents _ ''.
	self calculateKeyArray