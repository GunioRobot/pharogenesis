saveLibToDisk: evt
	| newName f snd |
	newName _ FillInTheBlank request: 'Please confirm name for library...'
						initialAnswer: 'MySounds'.
	newName isEmpty ifTrue: [^ self].
	f _ FileStream newFileNamed: newName , '.fml'.
	AbstractSound soundNames do:
		[:name | snd _ AbstractSound soundNamed: name.
		"snd isStorable" true ifTrue: [f nextChunkPut: 'AbstractSound soundNamed: ' , name , ' put: ' , snd storeString; cr; cr]
			ifFalse: [PopUpMenu notify: name , ' is not currently storable']].
	f close