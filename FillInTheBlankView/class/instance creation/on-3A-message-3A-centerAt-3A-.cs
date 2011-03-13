on: aFillInTheBlank message: queryString centerAt: aPoint
	"Answer an instance of me on aFillInTheBlank for a single line of input in response to the question queryString."

	aFillInTheBlank acceptOnCR: true.
	^ self
		multiLineOn: aFillInTheBlank
		message: queryString
		centerAt: aPoint
		answerHeight: 40
