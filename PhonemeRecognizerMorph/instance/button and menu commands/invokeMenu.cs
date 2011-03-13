invokeMenu
	"Invoke the settings menu."

	| aMenu |
	aMenu := CustomMenu new.
	aMenu title: 'Phoneme Recognizer'.
	aMenu addList:	#(
		('add phoneme'				addPhoneme)
		('play phoneme'				playPhoneme)
		('show phoneme features'	showPhonemeFeatures)
		('change phoneme name'	changePhonemeDetails)
		('set phoneme for silence'	setSilentPhoneme)
		('delete phoneme'			deletePhoneme)
		-
		('mouth position tile'		makeTile)
		('phoneme name tile'		makePhonemeNameTile)
		('match sound file'			matchSoundFile)
		-
		('save phonemes to file'		savePhonemes)
		('read phonemes from file'	readPhonemes)
		-
		('help'						presentHelp)).
	aMenu invokeOn: self defaultSelection: nil.
