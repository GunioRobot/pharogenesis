buildAnswerView: aFillInTheBlank frameWidth: widthInteger height: aHeight

	| answerView |
	answerView _ self new model: aFillInTheBlank.
	answerView window: (0@0 extent: widthInteger @ aHeight).
	answerView borderWidth: 2.
	^ answerView