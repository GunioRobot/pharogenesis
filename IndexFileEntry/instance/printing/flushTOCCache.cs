flushTOCCache
	"Flush my cached table-of-contents entry string."
	"IndexFileEntry allInstancesDo: [: e | e flushTOCCache]"

	tocLineCache _ nil.