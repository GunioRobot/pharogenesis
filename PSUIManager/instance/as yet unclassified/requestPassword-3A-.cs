requestPassword: aStringOrText 
	"Request for a password.
	Allow for interception with a ProvideAnswerNotification handler.
	Answer nil if the user cancels."
	
	(ProvideAnswerNotification signal: aStringOrText) ifNotNilDo: [:answer |
		^answer == #default ifTrue: [''] ifFalse: [answer]].
	^UITheme current 
		passwordEntryIn: self modalMorph
		text: aStringOrText
		title: 'Password Required' translated
		entryText: ''