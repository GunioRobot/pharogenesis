chooseTargetSubmorphOf: root caption: caption
	"Put up a menu of possible target names, with the given caption"

	| possibleTargets menu |
	possibleTargets _ root morphsAt: menuTargetOffset.
	possibleTargets size = 1 ifTrue: [^ possibleTargets first].
	menu _ CustomMenu new.
	possibleTargets do: [:m | menu add: (self submorphNameFor: m) action: m].
	^ caption size == 0
		ifTrue:
			[menu startUp]
		ifFalse:
			[menu startUpWithCaption: caption]