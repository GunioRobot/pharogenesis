storePreferencesIn: aFileName
	| stream |
	#(Prevailing PersonalPreferences) do: [ :ea | Parameters removeKey: ea ifAbsent: []].  
	stream _ ReferenceStream fileNamed: aFileName.
	stream nextPut: Parameters.
	stream nextPut: DictionaryOfPreferences.
	Smalltalk isMorphic
		ifTrue: [ stream nextPut: World fillStyle ]
		ifFalse: [ stream nextPut: DesktopColor ].
	stream close.