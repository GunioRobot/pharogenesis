updateFont
	"Update the label font."

	self tabs do: [:t |
		 ((t submorphs first isKindOf: StringMorph) or: [t submorphs first isTextMorph])
			ifTrue: [t submorphs first font: self font]]