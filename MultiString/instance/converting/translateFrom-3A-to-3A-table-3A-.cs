translateFrom: start to: stop table: table
	"translate the characters in the string by the given table, in place"

	self flag: #whatToDoWithThis.
	super translateFrom: start to: stop table: table.
