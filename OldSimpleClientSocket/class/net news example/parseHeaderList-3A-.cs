parseHeaderList: aString
	"Parse a list of newsgroup headers."

	| results s lineStart |
	results _ WriteStream on: (String new: aString size).
	s _ ReadStream on: aString.
	[s atEnd]
		whileFalse: [
			lineStart _ s position + 1.
			3 timesRepeat: [s skipTo: Character tab].  "find fourth tab"
			lineStart to: s position - 1 do: [:i | results nextPut: (aString at: i)].
			results cr.
			s skipTo: Character cr].
	^ results contents
