initializeTranspositionTable
	"Initialize the transposition table. Note: For now we only use 64k entries since they're somewhat space intensive. If we should get a serious speedup at some point we may want to increase the transposition table - 256k seems like a good idea; but right now 256k entries cost us roughly 10MB of space. So we use only 64k entries (2.5MB of space).
	If you have doubts about the size of the transition table (e.g., if you think it's too small or too big) then modify the value below and have a look at ChessTranspositionTable>>clear which can print out some valuable statistics.
	"
	transTable _ ChessTranspositionTable new: 16. "1 << 16 entries"