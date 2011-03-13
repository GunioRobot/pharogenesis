promptForDetailsOfPhoneme: phoneme
	"Prompt the user for the name and mouth position of the given phoneme."

	| response |
	response := FillInTheBlank
		request: 'Phoneme name?'
		initialAnswer: phoneme name.
	response ifNotNil: [phoneme name: response].

	response := FillInTheBlank
		request: 'Mouth Position Index?'
		initialAnswer: phoneme mouthPosition printString.
	response ifNotNil: [phoneme mouthPosition: response asNumber asInteger].

