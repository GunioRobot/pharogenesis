establishEtoyLabelWording
	"Set the label wording, unless it has already been manually edited"

	| itsName |

	self isTileScriptingElement ifFalse: [^self].
	itsName _ target externalName.
	self addTextToButton: itsName, ' ', arguments first.
	visibleMorph setBalloonText: 
		'click to run the script "', 
		arguments first, 
		'" in player named "', 
		itsName, '"'