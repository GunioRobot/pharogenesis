removeUnreferencedPlayers
	"Remove existing but unreferenced player references"
	"StandardScriptingSystem removeUnreferencedPlayers"
	References keys do: 
		[:key | (References at: key) costume pasteUpMorph
			ifNil: [References removeKey: key]].
