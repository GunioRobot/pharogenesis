formatedMessageText
	"Answer a string that is my formatted mail message."
	| message header body bodyText |
	currentMsgID isNil ifTrue: [^ ''].
	message _ self currentMessage.
	header _ message cleanedHeader.
	body _ message body.
	body contentType = 'text/html'
		ifTrue: [bodyText _ (HtmlParser parse: (ReadStream on: body content)) formattedText]
		ifFalse: [bodyText _ body content].
	^ header asText , String cr , bodyText