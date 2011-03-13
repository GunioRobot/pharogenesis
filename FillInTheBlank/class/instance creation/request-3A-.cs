request: messageString
	"Create an instance of me whose question is messageString. Display it 
	centered around the cursor. Answer whatever the user accepts."

	^self request: messageString initialAnswer: ''