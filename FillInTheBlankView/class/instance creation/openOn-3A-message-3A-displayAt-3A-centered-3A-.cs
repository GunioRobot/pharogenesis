openOn: aFillInTheBlank message: messageString displayAt: originPoint centered: centered
	"Create and schedule an instance of me that displays aFillInTheBlank 
	asking the question messageString. If the argument centered, a Boolean, 
	is false, display the instance with top left corner at originPoint; 
	otherwise, display it with its center at originPoint. Do not schedule, 
	rather take control immediately and insist that the user respond."

	^ self openOn: aFillInTheBlank message: messageString displayAt: originPoint centered: centered answerHeight: 40 windowTitle: 'Type a response'