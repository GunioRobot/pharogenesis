on: aFillInTheBlank message: messageString displayAt: originPoint centered: centered 
	"Answer an instance of me on the model aFillInTheBlank asking the 
	question messageString. If the argument centered, a Boolean, is false, 
	display the instance with top left corner at originPoint; otherwise, 
	display it with its center at originPoint."

	| topView messageView answerView |
	messageView _ self buildMessageView: messageString.
	answerView _ 
		self buildAnswerView: aFillInTheBlank 
			frameWidth: messageView window width.
	answerView controller: CRFillInTheBlankController new.
	topView _ View new model: aFillInTheBlank.
	topView controller: ModalController new.
	topView addSubView: messageView.
	topView addSubView: answerView below: messageView.
	topView align: (centered
			ifTrue: [topView viewport center]
			ifFalse: [topView viewport topLeft])
		with: originPoint.
	topView window: 
		(0 @ 0 extent: 
			messageView window width @ 
			(messageView window height + answerView window height)).
	topView translateBy:
		(topView displayBox amountToTranslateWithin: Display boundingBox).
	^topView