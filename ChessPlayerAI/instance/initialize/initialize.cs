initialize
	historyTable _ ChessHistoryTable new.
	"NOTE: transposition table is initialized only when we make the first move. It costs a little to do all the entries and the garbage collections so we do it only when we *really* need it."
	transTable _ nil.
	random _ Random new.
	nodesVisited _ ttHits _ alphaBetaCuts _ stamp _ 0.
	variations _ Array new: 11.
	1 to: variations size do:[:i| 
		variations at: i put: (Array new: variations size).
		(variations at: i) atAllPut: 0].
	bestVariation _ Array new: variations size.
	bestVariation atAllPut: 0.
	activeVariation _ Array new: variations size.
	activeVariation atAllPut: 0.
	self reset.