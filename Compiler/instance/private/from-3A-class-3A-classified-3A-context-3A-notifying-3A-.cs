from: textOrStream class: aClass classified: aCategory context: aContext notifying: req

	(textOrStream isKindOf: PositionableStream)
		ifTrue: [sourceStream  := textOrStream]
		ifFalse: [sourceStream  := ReadStream on: textOrStream asString].
	class  := aClass.
	context  := aContext.
	requestor  := req.
	category  := aCategory
