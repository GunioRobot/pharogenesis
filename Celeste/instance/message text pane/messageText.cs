messageText
	"Answer the text which makes up the complete message (header+body)"

	mailDB ifNil: [ ^self messageTextIfNoDB ].
	(currentMsgID isNil) ifTrue: [^''].

	"Always show the full message header for messages in the category .tosend. so that all special header lines are preserved, shown and can be edited."
	(self currentCategory = '.tosend.')
		ifTrue: [^ (mailDB getText: currentMsgID) isoToSqueak].

	SuppressWorthlessHeaderFields
		ifTrue: [^ (self currentMessage formattedText)]
		ifFalse: [^ (mailDB getText: currentMsgID) isoToSqueak].
