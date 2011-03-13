request: aStringOrText initialAnswer: defaultAnswer 
	"Create an instance of me whose question is queryString with the given 
	initial answer. Answer the string the user accepts.
	Answer the empty string if the user cancels.
	Allow for interception with a ProvideAnswerNotification handler."
	
	(ProvideAnswerNotification signal: aStringOrText) ifNotNilDo: [:answer |
		^answer == #default ifTrue: [defaultAnswer] ifFalse: [answer]].
	^(UITheme current
		textEntryIn: self modalMorph
		text: aStringOrText
		title: 'Information Required' translated
		entryText: defaultAnswer)