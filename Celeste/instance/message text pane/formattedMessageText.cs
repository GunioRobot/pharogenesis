formattedMessageText
	"Answer a string that is my formatted mail message."
	| message header body bodyText |
	currentMsgID isNil ifTrue: [^ ''].
	message _ self currentMessage.
	header _ message cleanedHeader.
	body _ message body.

	bodyText _ body contentType = 'text/html' ifTrue: [
		Smalltalk at: #HtmlParser ifPresent: [ :htmlParser |
			(htmlParser parse: (ReadStream on: body content)) formattedText]].

	bodyText ifNil: [ bodyText _ body content ].
	^ header asText , String cr , bodyText