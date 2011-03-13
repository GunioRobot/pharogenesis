cleanUpEtoys
	"self new cleanUpEtoys"

	StandardScriptingSystem removeUnreferencedPlayers.

	(self confirm: 'Remove all projects and players?')
		ifFalse: [^self].
	Project removeAllButCurrent.

	#('Morphic-UserObjects' 'EToy-UserObjects' 'Morphic-Imported' )
		do: [:each | SystemOrganization removeSystemCategory: each].
		
	Smalltalk
		at: #Player
		ifPresent: [:superCls | superCls
				allSubclassesDo: [:cls | 
					cls isSystemDefined
						ifFalse: [cls removeFromSystem].
					cls := nil]].