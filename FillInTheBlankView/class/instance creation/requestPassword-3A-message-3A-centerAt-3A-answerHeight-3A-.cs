requestPassword: aFillInTheBlank message: queryString centerAt: aPoint answerHeight: answerHeight
	"Answer an instance of me on aFillInTheBlank asking the question queryString. Allow the reply to be multiple lines, and make the user input view the given height."

	| messageView answerView topView myPar pwdFont myArray myStyle |
	aFillInTheBlank acceptOnCR: true.
	messageView _ DisplayTextView new
		model: queryString asDisplayText;
		borderWidthLeft: 2 right: 2 top: 2 bottom: 0;
		controller: NoController new.
	messageView
		window: (0@0 extent: (messageView window extent max: 200@30));
		centered.
	answerView _ self new
		model: aFillInTheBlank;
		window: (0@0 extent: (messageView window width@answerHeight));
		borderWidth: 2.
	" now answerView to use the password font"
	myPar _ answerView displayContents.
	pwdFont _ (StrikeFont passwordFontSize: 12).
	myArray _ Array new: 1.
	myArray at: 1 put: pwdFont.
	myStyle _ TextStyle fontArray: myArray.
	myPar setWithText: (myPar text) style: myStyle.

	topView _ View new model: aFillInTheBlank.
	topView controller: ModalController new.
	topView addSubView: messageView.
	topView addSubView: answerView below: messageView.
	topView align: topView viewport center with: aPoint.
	topView window:
		(0 @ 0 extent:
			(messageView window width) @
			  (messageView window height + answerView window height)).
	topView translateBy:
		(topView displayBox amountToTranslateWithin: Display boundingBox).
	^ topView
