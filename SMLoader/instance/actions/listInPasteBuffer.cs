listInPasteBuffer
	"Useful when talking with people etc.
	Uses the map to produce a nice String."

	Clipboard clipboardText:
		(String streamContents: [:s |
			packagesList do: [:p |
				s nextPutAll: p nameWithVersionLabel; cr ]]) asText