createButtonsBar
	| controlPosition moveStyleButton helpButton prevButton sameButton nextButton quitButton |
	controlPosition _ currentMap borderSpace + (bounds origin x @ bounds corner y).
	"Instructions"
	helpButton _ self
				createButtonFor: #showHelpWindow
				shortText: '?'
				longText: '? Help' translated
				hint: 'Shows instructions' translated.
	helpButton position: controlPosition.
	self addMorph: helpButton.
	"Go to previous map"
	controlPosition _ controlPosition + (helpButton bounds width * 1.5 @ 0).
	prevButton _ self
				createButtonFor: #goPrevLevel
				shortText: '<<'
				longText: '< Prev' translated
				hint: 'Jumps to the previous level' translated.
	prevButton position: controlPosition.
	self addMorph: prevButton.
	"Restart this map"
	controlPosition _ controlPosition + (prevButton bounds width * 1.2 @ 0).
	sameButton _ self
				createButtonFor: #goSameLevel
				shortText: 'Rst' translated
				longText: 'Reset' translated
				hint: 'Restarts this level' translated.
	sameButton position: controlPosition.
	self addMorph: sameButton.
	"Go to next map"
	controlPosition _ controlPosition + (sameButton bounds width * 1.2 @ 0).
	nextButton _ self
				createButtonFor: #goNextLevel
				shortText: '>>'
				longText: 'Next >' translated
				hint: 'Jumps to the next level' translated.
	nextButton position: controlPosition.
	self addMorph: nextButton.
	"Moves style"
	controlPosition _ controlPosition + (nextButton bounds width * 1.5 @ 0).
	moveStyleButton _ self
				createSwitchButtonFor: #moveStyleState:
				shortText: 'F'
				longText: 'Fast'
				state: fastMoves
				hint: 'Animation on/off' translated.
	moveStyleButton position: controlPosition.
	self addMorph: moveStyleButton.
	"Close the game"
	controlPosition _ controlPosition + (nextButton bounds width * 1.5 @ 0).
	quitButton _ self
				createButtonFor: #delete
				shortText: '[X]'
				longText: 'Quit' translated
				hint: 'Closes the game' translated.
	quitButton position: controlPosition.
	self addMorph: quitButton.
	"Extends the morph bound"
	bounds _ bounds extendBy: 0 @ prevButton bounds height.
	bounds _ bounds extendBy: currentMap borderSpace