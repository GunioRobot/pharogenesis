format: requestObject
	"format text with requestObject as the argument for the code blocks"
	^String streamContents: [ :stream |
		formattingBlock value: requestObject value: stream ]