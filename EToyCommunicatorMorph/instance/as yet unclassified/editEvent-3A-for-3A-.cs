editEvent: anEvent for: aMorph

	| answer |

	(aMorph bounds containsPoint: anEvent cursorPoint) ifFalse: [^self].
	answer _ FillInTheBlankMorph
		request: 'Enter a new ',aMorph balloonText
		initialAnswer: aMorph contents.
	answer isEmptyOrNil ifTrue: [^self].
	aMorph contents: answer
