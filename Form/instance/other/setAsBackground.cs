setAsBackground
	"Set this form as a background image."

	| world newColor |
	Smalltalk isMorphic 
		ifTrue:
			[world _ self currentWorld.
			newColor _ InfiniteForm with: self.
			self rememberCommand:
				(Command new cmdWording: 'set background to a picture' translated;
					undoTarget: world selector: #color: argument: world color;
					redoTarget: world selector: #color: argument: newColor).
			world color: newColor]
		ifFalse:
			[ScheduledControllers screenController model form: self.
			Display restoreAfter: []]