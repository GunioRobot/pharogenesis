activeCategoryName
	"Answer the name to be used for the active-methods category"

	true ifTrue: [^ #'-- current working set --'].

	'-- current working set --' asSymbol "Placed here so a message-strings-containing-it query will find this method"
