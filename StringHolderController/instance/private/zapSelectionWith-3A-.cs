zapSelectionWith: aText
	"Lock model, except during typeIn, which locks at close (in case 'again' follows)"

	super zapSelectionWith: aText.
	beginTypeInBlock == nil ifTrue: [self lockModel]