fromExistingMethod: aSelector forPlayer: aPlayer 
	"Create tiles for this method.  "

	| parseTree |
	self initialize.
	playerScripted _ aPlayer.
	self setMorph: aPlayer costume scriptName: aSelector.
	parseTree _ (Decompiler new) decompile: aSelector
		in: aPlayer class 
		method: (aPlayer class compiledMethodAt: aSelector).
	self tilesFrom: parseTree.
	self install.