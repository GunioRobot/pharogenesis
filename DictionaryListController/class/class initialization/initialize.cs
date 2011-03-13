initialize

	DictionaryListYellowButtonMenu _
		PopUpMenu labels:
'inspect
references
add key
remove'
		lines: #( 2 ).
	DictionaryListYellowButtonMessages _
		#(inspectSelection selectionReferences addEntry removeSelection )

	"DictionaryListController initialize"