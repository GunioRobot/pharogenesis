rawText
	"Answer the unparsed text for this entry."
	^ messageFile
			getMessage: msgID
			at: location
			textLength: textLength