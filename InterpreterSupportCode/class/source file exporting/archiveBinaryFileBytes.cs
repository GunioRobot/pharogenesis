archiveBinaryFileBytes
	"Convert the Mac CodeWarrier Project archive data into a ByteArray."

	| data b |
	data _ self macArchiveBinaryFile.
	b _ ByteArray new: data size.
	1 to: data size do: [ :i | b at: i put: (data at: i)].
	^ b
