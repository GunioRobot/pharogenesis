primWrite: id from: stringOrByteArray startingAt: startIndex count: count
	"Write count bytes onto this file from the given string or byte array starting at the given index. Answer the number of bytes written."

	<primitive: 158>
	self closed ifTrue: [^ self error: 'File is closed'].
	self error: 'File write failed'.
