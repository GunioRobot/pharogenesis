displayBuffer
	"the 'screen' of the terminal"
	^Text streamContents: [ :s |
		displayLines do: [ :line |
			s nextPutAll: line.
			s cr. ] ]