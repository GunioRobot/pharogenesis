reset
	"Reset the board, choosing anew how many teams."

	| nPlayers nHumans |
	nPlayers _ (SelectionMenu selections: (1 to: 6)) startUpWithCaption: 'How many players?'.
	nPlayers ifNil: [nPlayers _ 2].
	nHumans _ (SelectionMenu selections: (0 to: nPlayers)) startUpWithCaption: 'How many humans?'.
	nHumans ifNil: [nHumans _ 1].
	self teams: (#((1) (2 5) (2 4 6) (1 2 4 5) (1 2 3 4 6) (1 2 3 4 5 6)) at: nPlayers)
		 autoPlay: ((1 to: nPlayers) collect: [:i | i > nHumans]).
