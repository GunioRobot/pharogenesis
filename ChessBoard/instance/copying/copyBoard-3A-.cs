copyBoard: aBoard 
	"Copy all volatile state from the given board"

	whitePlayer copyPlayer: aBoard whitePlayer.
	blackPlayer copyPlayer: aBoard blackPlayer.
	activePlayer := aBoard activePlayer isWhitePlayer 
				ifTrue: [whitePlayer]
				ifFalse: [blackPlayer]. 
	hashKey := aBoard hashKey.
	hashLock := aBoard hashLock.
	userAgent := nil