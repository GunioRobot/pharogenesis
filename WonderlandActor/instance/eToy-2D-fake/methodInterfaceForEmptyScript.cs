methodInterfaceForEmptyScript
	"Copied from Player"

	| anInterface |
	anInterface _ MethodInterface new.
	anInterface documentation: 'an empty script; drop on desktop to get a new empty script for this object.'.
	anInterface receiverType: #none.
	anInterface flagAttribute: #scripts.

	anInterface absorbTranslation: 
		(ElementTranslation new wording: #emptyScript helpMessage: 'an empty script; drop on desktop to get a new empty script for this object.' language: #English).

	anInterface selector: #emptyScript type: nil setter: nil.
	^ anInterface