phraseToTranslate
	"answer a phrase to translate.  use the selected untranslated phrase or ask for a new one"
	^ self selectedUntranslated isZero
		ifTrue: [FillInTheBlank
				multiLineRequest: 'new phrase to translate' translated
				centerAt: Sensor cursorPoint
				initialAnswer: ''
				answerHeight: 200]
		ifFalse: [self untranslated at: self selectedUntranslated]