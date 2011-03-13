confirm: aStringOrText
	"Put up a question dialog (without cancel) with the text queryString.
	Answer true if the response is yes, false if no.
	This is a modal question--the user must respond yes or no."
	
	(ProvideAnswerNotification signal: aStringOrText) ifNotNilDo: [:answer |
		^answer].
	^UITheme current 
		questionWithoutCancelIn: self modalMorph
		text: aStringOrText
		title: 'Question' translated