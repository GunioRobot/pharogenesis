initializeWith: aWonderland
	"Initialize the instance"

	| exitButton resetButton undoButton |

	myWonderland _ aWonderland.
	myScheduler _ myWonderland getScheduler.

	"Use a white background"
	color _ (Color r: 0.784 g: 0.784 b: 0.784).

	"Now add our buttons"
	undoButton _ SimpleButtonMorph new.
	undoButton initialize.
	undoButton label: 'Undo'.
	undoButton color: (Color green).
	undoButton target: myWonderland.
	undoButton actionSelector: #undo.
	self addMorph: undoButton.

	resetButton _ SimpleButtonMorph new.
	resetButton initialize.
	resetButton label: 'Reset'.
	resetButton color: (Color yellow).
	resetButton target: myWonderland.
	resetButton actionSelector: #reset.
	self addMorph: resetButton.

	exitButton _ SimpleButtonMorph new.
	exitButton initialize.
	exitButton label: 'Quit'.
	exitButton color: (Color red).
	exitButton target: self.
	exitButton actionSelector: #quitWonderland.
	self addMorph: exitButton.

	undoButton bounds: (5@10 corner: 45@40).
	resetButton bounds: (50@10 corner: 90@40).
	exitButton bounds: (95@10 corner: 135@40).

	"Size and position the window"
	self extent: 140@50.
