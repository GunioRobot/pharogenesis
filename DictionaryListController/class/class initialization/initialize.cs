initialize
	DictionaryListYellowButtonMenu _
		PopUpMenu labels:
'inspect
references
objects pointing to this value
add key
remove'
		lines: #( 3 ).
	DictionaryListYellowButtonMessages _
		#(inspectSelection selectionReferences objectReferencesToSelection addEntry removeSelection )

	"DictionaryListController initialize"