vmTable: tableIndex at: index
	"tableIndex is a negative integer corresponding to one of the VM's internal tables.
	Answer with the value in the table at the given index (counting from 1).  Index 0
	'contains' the size (i.e. largest legal index) of the table."

	<primitive: 254>
	self primitiveFailed