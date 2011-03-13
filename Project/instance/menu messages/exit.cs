exit
	"Leave the current project and return to the project in which this one was created."

	self isTopProject ifTrue: [^ PopUpMenu notify: 'Can''t exit the top project'].
	Smalltalk at: #ScorePlayer ifPresent: [:playerClass |
		playerClass allInstancesDo: [:player | player pause]].
	activeProcess _ nil.
	parentProject enter: false.
