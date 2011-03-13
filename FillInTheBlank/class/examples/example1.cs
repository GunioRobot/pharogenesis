example1

	FillInTheBlank
		message: 'What is your name?' 
		displayAt: Sensor waitButton 
		centered: true
		action: [:answer | Transcript cr; show: answer] 
		initialAnswer: ''

	"FillInTheBlank example1"