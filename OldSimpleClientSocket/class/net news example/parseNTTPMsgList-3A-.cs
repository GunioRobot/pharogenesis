parseNTTPMsgList: aString
	"Parse a list of integers, each on a line by itself."

	| s out |
	s _ ReadStream on: aString.
	s skipTo: Character cr.  "skip the first line"
	out _ OrderedCollection new.
	[s atEnd]
		whileFalse: [
			out addLast: (Integer readFrom: s).
			s skipTo: Character cr].
	^ out asArray
