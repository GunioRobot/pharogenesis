writeList: listContents toStream: strm
	"Write a parsed updates.list out as text.
	This is the inverse of parseListContents:"

	| fileNames version |
	strm reset.
	listContents do:
		[:pair | version _ pair first.  fileNames _ pair last.
		strm nextPut: $#; nextPutAll: version; cr.
		fileNames do: [:fileName | strm nextPutAll: fileName; cr]].
	strm close