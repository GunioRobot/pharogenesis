addProgressIndicator: aValueHolder 
	progress := ProgressBarMorph new.
	progress borderWidth: 1.
	progress color: Color transparent.
	progress progressColor: Color gray.
	progress value: aValueHolder.
	progress extent: 100 @ (startButton extent y - 6).
	self addMorph: progress