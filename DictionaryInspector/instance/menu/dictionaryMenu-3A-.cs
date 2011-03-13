dictionaryMenu: aMenu

	^ aMenu labels:
'inspect
copy name
references
objects pointing to this value
add key
remove
basic inspect'
	lines: #( 4 6)
	selections: #(inspectSelection copyName selectionReferences objectReferencesToSelection addEntry removeSelection inspectBasic)
