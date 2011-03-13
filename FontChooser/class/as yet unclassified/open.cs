open
	"
	FontChooser open.
	"
	| instance morph |
	instance := self new.
	(morph := FontChooserMorph withModel: instance)
		openInWorld.
	^morph