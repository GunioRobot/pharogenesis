allHelpStrings
	| aList |
	aList _ OrderedCollection new.
	FlagDictionary keysDo:
		[:aKey  | aList add: (self helpMessageForPreference: aKey)].
	^ aList