allCategoryName
	"Answer the name to be used for the all category"

	true ifTrue: [^ #'-- all --'].

	'-- all --' asSymbol  "Placed here so a message-strings-containing-it query will find this method"
