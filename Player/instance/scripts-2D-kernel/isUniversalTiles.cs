isUniversalTiles
	| ww |
	"Return true if I (my world) uses universal tiles.  This message can be called in places where the current World is not known, such as when writing out a project."

	^ (ww _ costume world)	 "new tiles?"
		ifNil: [ScriptEditorMorph writingUniversalTiles == true
				"only valid during a project write"]
		ifNotNil: [ww valueOfProperty: #universalTiles ifAbsent: [false]]