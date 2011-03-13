colorForInsets
	"My submorphs use the surrounding color"

	owner color isColor ifTrue:[^ owner color].
	^ Color white