scanToNextMessageIn: aStream
	"Scan to the start of the next message in the given stream. Answer true if we find a message delimiter, false if we hit the end of the stream first. The stream is left positioned at the start of the next message or at the end of the stream."

	| msgStart line dayOfWeek year |
	[aStream atEnd] whileFalse: [
		(self findPossibleMessageStart: aStream) ifFalse: [^false].
		msgStart _ aStream position.
		aStream next: 5.  "skip 'From '"

		"skip address"
		[aStream peek isSeparator] whileFalse: [aStream next].
		[aStream peek = Character space] whileTrue: [aStream next].

		line _ MailDB readStringLineFrom: aStream.
		line size >= 7 ifTrue: [
			dayOfWeek _ (line copyFrom: 1 to: 3) asLowercase.
			year _ (line at: line size - 3) isDigit
					ifTrue: [(line copyFrom: line size - 3 to: line size) asNumber]
					ifFalse: [0].
			((#('sun' 'mon' 'tue' 'wed' 'thu' 'fri' 'sat') includes: dayOfWeek) and:
			[(year > 1900) and: [year < 2100]]) ifTrue: [
				aStream position: msgStart.
				^true  "found a message!"
			].
		].
	].
	^false