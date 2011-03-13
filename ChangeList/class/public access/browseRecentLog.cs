browseRecentLog    "ChangeList browseRecentLog"
	"Browse changes logged since last quit"
	^ self browseRecent: (SourceFiles at: 2) size - Smalltalk lastQuitLogPosition