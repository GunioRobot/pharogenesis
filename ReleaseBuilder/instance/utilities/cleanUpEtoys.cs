cleanUpEtoys
	"ReleaseBuilder new cleanUpEtoys"


	StandardScriptingSystem removeUnreferencedPlayers.

	(self confirm: 'Remove all projects and players?')
		ifFalse: [^self].
	Project removeAllButCurrent.

	#('Morphic-UserObjects' 'EToy-UserObjects' 'Morphic-Imported' )
		do: [:each | SystemOrganization removeSystemCategory: each]