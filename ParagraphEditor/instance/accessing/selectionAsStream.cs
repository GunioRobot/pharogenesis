selectionAsStream
	"Answer a ReadStream on the text in the paragraph that is currently 
	selected."

	^ReadWriteStream
		on: paragraph string
		from: startBlock stringIndex
		to: stopBlock stringIndex - 1