with: voiceString say: contentString
	"Speak the string"

	^self doIt: 'say "', contentString, '" using "', voiceString, '"'
