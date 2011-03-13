on: anObject list: getListSel selected: getSelectionSel changeSelected: setSelectionSel
	"Answer a new instance of the receiver on the given model using
	the given selectors as the interface."

	^self new
		on: anObject 
		list: getListSel
		selected: getSelectionSel
		changeSelected: setSelectionSel