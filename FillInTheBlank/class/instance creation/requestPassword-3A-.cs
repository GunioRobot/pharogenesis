requestPassword: queryString 
	"Create an instance of me whose question is queryString. Invoke it centered
	at the cursor, and answer the string the user accepts. Answer the empty 
	string if the user cancels."

	"FillInTheBlank requestPassword: 'POP password'"

	| model fillInView |
	Smalltalk isMorphic 
		ifTrue: [^self fillInTheBlankMorphClass requestPassword: queryString].
	model := self new.
	model contents: ''.
	fillInView := self fillInTheBlankViewClass 
				requestPassword: model
				message: queryString
				centerAt: Sensor cursorPoint
				answerHeight: 40.
	^model show: fillInView