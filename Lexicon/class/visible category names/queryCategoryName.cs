queryCategoryName
	"Answer the name to be used for the query-results category"

	true ifTrue: [^ #'-- query results --'].

	^ '-- query results --' asSymbol   "Placed here so a message-strings-containing-it query will find this method"