fillForProjectTarget
	"Find a fill style that is suitable for a project target."
	shape fillStyles do:[:fs| fs isBitmapFill ifTrue:[^fs]].
	^nil