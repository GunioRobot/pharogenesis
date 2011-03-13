example2

	FillInTheBlank
		request: 'What is your name?' 
		displayAt: Sensor waitButton 
		centered: true
		action: [:answer | Transcript cr; show: answer] 
		initialAnswer: 'Your Name'

	"FillInTheBlank example2"