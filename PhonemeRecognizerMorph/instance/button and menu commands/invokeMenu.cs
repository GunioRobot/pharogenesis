invokeMenu
	"Invoke the settings menu."

	| aMenu |
	aMenu _ CustomMenu new.
	aMenu addList:	#(
		('add phoneme'				addPhoneme)
		('play phoneme'				playPhoneme)
		('show phoneme features'	showPhonemeFeatures)
		('change phoneme name'	changePhonemeDetails)
		('set phoneme for silence'	setSilentPhoneme)
		('delete phoneme'			deletePhoneme)
		-
		('mouth position tile'		makeTile)
		('match sound file'			matchSoundFile)
		-
		('save phonemes to file'		savePhonemes)
		('read phoneme from file'	readPhonemes)).
	aMenu invokeOn: self defaultSelection: nil.
