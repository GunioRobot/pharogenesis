selectTargetMorph: caption excluding: morphToExclude
	"Put up a menu of morphs found in a core sample taken of the world at the receiver's menuTargetOffset, with the given caption, but exclude morphToExclude and all of its submorphs.  This latter is for use with embed/place facilties, to avoid strange loops. "

	| possibleTargets menu |
	possibleTargets _ argument pasteUpMorph morphsAt: menuTargetOffset.
	morphToExclude ifNotNil:
		[possibleTargets removeAllFoundIn: morphToExclude allMorphs].
	possibleTargets size < 2 ifTrue:
		[self inform: 'Sorry -- not applicable here'.
		^ nil].

	menu _ CustomMenu new.
	possibleTargets do: [:m | menu add: (self submorphNameFor: m) action: m].
	^ caption size == 0
		ifTrue:
			[menu startUp]
		ifFalse:
			[menu startUpWithCaption: caption]