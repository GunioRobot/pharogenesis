buildQuitButton
	"private - create the [quit] button"
	^ self
		buttonName: 'Quit' translated
		target: self
		action: #quit