inform: aStringOrText
	"Display a message for the user to read and then dismiss."
	
	(ProvideAnswerNotification signal: aStringOrText) ifNotNilDo: [:answer |
		^true].
	^UITheme current
		messageIn: self modalMorph
		text: aStringOrText
		title: 'Information' translated