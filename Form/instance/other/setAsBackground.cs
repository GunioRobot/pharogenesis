setAsBackground
	"Set this form as a background image."
	| world newColor |
	world := self currentWorld.
	newColor := InfiniteForm with: self.
	self rememberCommand: (Command new cmdWording: 'set background to a picture' translated;
			
			undoTarget: world
			selector: #color:
			argument: world color;
			
			redoTarget: world
			selector: #color:
			argument: newColor).
	world color: newColor