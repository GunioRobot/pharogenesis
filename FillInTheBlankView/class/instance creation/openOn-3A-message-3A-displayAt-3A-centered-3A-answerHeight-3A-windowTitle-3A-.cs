openOn: aFillInTheBlank message: messageString displayAt: originPoint centered: centered answerHeight: answerHeight windowTitle: windowTitle
	"Do not schedule, rather take control immediately and insist that the user respond."

	| topView messageView answerView |
	messageView _ self buildMessageView: messageString.
	answerView _ 
		self buildAnswerView: aFillInTheBlank 
			frameWidth: messageView window width height: answerHeight.
	topView _ StandardSystemView new model: aFillInTheBlank.
	topView addSubView: messageView.
	topView addSubView: answerView below: messageView. 
	topView
		align: (centered
				ifTrue: [topView viewport center]
				ifFalse: [topView viewport topLeft])
		with: originPoint.
	topView label: windowTitle.
	topView window: 
		(0@0 extent: messageView window width @ (messageView window height + answerHeight)).
	topView controller openDisplayAt: originPoint