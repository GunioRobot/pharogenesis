selectEmbedTargetMorph: caption
	"Put up a menu of morphs found in a core sample taken of the world at the receiver's menuTargetOffset, with the given caption"
	|  menu |
	menu _ CustomMenu new.
	self potentialEmbeddingTargets  do: [:m | menu add: (self submorphNameFor: m) action: m].
	^ caption size == 0
		ifTrue:
			[menu startUp]
		ifFalse:
			[menu startUpWithCaption: caption]