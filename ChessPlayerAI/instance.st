Object
	subclass: #ChessPlayerAI
	instanceVariableNames:
		'board boardList boardListIndex player historyTable transTable generator random variations activeVariation bestVariation nodesVisited ttHits stamp alphaBetaCuts startTime ply myMove myProcess stopThinking bestMove'
	classVariableNames:
		'AlphaBetaGiveUp AlphaBetaIllegal AlphaBetaMaxVal AlphaBetaMinVal ValueAccurate ValueBoundary ValueLowerBound ValueThreshold ValueUpperBound'
	poolDictionaries: 'ChessConstants'
	category: 'Morphic-Games-Chess'