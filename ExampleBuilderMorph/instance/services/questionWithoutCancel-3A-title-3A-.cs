questionWithoutCancel: aStringOrText title: aString
	"Open a question dialog and answer true if yes,
	false if no and nil if cancelled."

	^self theme
		questionWithoutCancelIn: self
		text: aStringOrText
		title: aString