okToChange
	"Allows a controller to ask this of any model"
	self selectedTranslation isZero
		ifTrue: [^ true].
	""
	translationText hasUnacceptedEdits
		ifFalse: [^ true].
	^ (CustomMenu confirm: 'Discard the changes to currently selected translated phrase?' translated)
		and: [""
			translationText hasUnacceptedEdits: false.
			true]