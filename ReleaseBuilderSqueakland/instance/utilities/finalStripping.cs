finalStripping
	"ReleaseBuilderSqueakland new finalStripping"

	#(#Helvetica #Palatino #Courier #ComicSansMS )
		do: [:n | TextConstants
				removeKey: n
				ifAbsent: []].
	Smalltalk
		at: #Player
		ifPresent: [:superCls | superCls
				allSubclassesDo: [:cls | 
					cls isSystemDefined
						ifFalse: [cls removeFromSystem].
					cls := nil]].
	Smalltalk garbageCollect.
	Smalltalk discardFFI; discardSUnit; discardSpeech; yourself.
	"discardMVC;"
	SystemOrganization removeEmptyCategories.
