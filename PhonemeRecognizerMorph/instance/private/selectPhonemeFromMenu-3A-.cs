selectPhonemeFromMenu: title
	"Answer the phone selected by the user from a menu of the current phoneme records. Answer nil if the user does not select any phoneme."

	| aMenu |
	recognizer phonemes isEmpty ifTrue: [self inform: 'The phoneme database is empty.'. ^ nil].
	aMenu := CustomMenu new title: title.
	recognizer phonemes do: [:phoneme |
		aMenu add: phoneme name action: phoneme].
	^ aMenu startUp
