chooseVocabulary
	"Put up a dialog affording the user a chance to choose a different vocabulary to be installed in the receiver"

	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addTitle: 'Choose a vocabulary
blue = current
red = imperfect' translated.
	aMenu addStayUpItem.
	Vocabulary allStandardVocabularies do:
		[:aVocabulary |
			(targetClass implementsVocabulary: aVocabulary)
				ifTrue:
					[aMenu add: aVocabulary vocabularyName selector: #switchToVocabulary: argument: aVocabulary.
					(targetClass fullyImplementsVocabulary: aVocabulary) ifFalse:
						[aMenu lastItem color: Color red].
					aVocabulary == currentVocabulary ifTrue:
						[aMenu lastItem color: Color blue]. 
					aMenu balloonTextForLastItem: aVocabulary documentation]].
	aMenu popUpInWorld: self currentWorld