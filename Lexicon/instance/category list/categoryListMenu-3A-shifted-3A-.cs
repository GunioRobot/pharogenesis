categoryListMenu: aMenu shifted: aBoolean
	"Answer the menu for the category list"

	^ aMenu labels: 'find...(f)' lines: #() selections: #(obtainNewSearchString)