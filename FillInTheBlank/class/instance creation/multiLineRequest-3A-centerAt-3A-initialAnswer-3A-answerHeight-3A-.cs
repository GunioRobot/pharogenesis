multiLineRequest: queryString centerAt: aPoint initialAnswer: defaultAnswer answerHeight: answerHeight 
	"Create a multi-line instance of me whose question is queryString with
	the given initial answer. Invoke it centered at the given point, and
	answer the string the user accepts.  Answer nil if the user cancels.  An
	empty string returned means that the ussr cleared the editing area and
	then hit 'accept'.  Because multiple lines are invited, we ask that the user
	use the ENTER key, or (in morphic anyway) hit the 'accept' button, to 
	submit; that way, the return key can be typed to move to the next line.
	NOTE: The ENTER key does not work on Windows platforms."

	"FillInTheBlank
		multiLineRequest:
'Enter several lines; end input by accepting
or canceling via menu or press Alt+s/Alt+l'
		centerAt: Display center
		initialAnswer: 'Once upon a time...'
		answerHeight: 200"

	| model fillInView |
	Smalltalk isMorphic 
		ifTrue: 
			[^self fillInTheBlankMorphClass 
				request: queryString
				initialAnswer: defaultAnswer
				centerAt: aPoint
				inWorld: self currentWorld
				onCancelReturn: nil
				acceptOnCR: false].
	model := self new.
	model contents: defaultAnswer.
	model responseUponCancel: nil.
	model acceptOnCR: false.
	fillInView := self fillInTheBlankViewClass 
				multiLineOn: model
				message: queryString
				centerAt: aPoint
				answerHeight: answerHeight.
	^model show: fillInView