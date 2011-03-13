instanceVariablesString
	"Answer a string of my instance variable names separated by spaces."

	^ String streamContents:
		[:strm | self instVarNames do: [:varName | strm nextPutAll: varName; space]]