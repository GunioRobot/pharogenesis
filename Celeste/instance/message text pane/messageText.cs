messageText
	"Answer the text which makes up the complete message (header+body)"

	(currentMsgID isNil) ifTrue: [^''].

	"Always show the full message header for messages in the category .tosend. so that all special header lines are preserved, shown and can be edited."
	(currentCategory = '.tosend.')
		ifTrue: [^ mailDB getText: currentMsgID].

	SuppressWorthlessHeaderFields
		ifTrue: [^ self currentMessage formattedText]
		ifFalse: [^ mailDB getText: currentMsgID].
