addProgressIndicator
	progress := ProgressBarMorph new.
	progress borderWidth: 1.
	progress color: Color transparent.
	progress progressColor: Color gray.
	progress extent: 100 @ (startButton extent y - 6).
	self addMorph: progress