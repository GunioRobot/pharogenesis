asUnHtml
	"Strip out all Html stuff (commands in angle brackets <>) and convert the characters &<> back to their real value.  Leave actual cr and tab as they were in text.  4/12/96 tk"
	| in out char rest did |
	in _ ReadStream on: self.
	out _ WriteStream on: (String new: self size).
	[in atEnd] whileFalse: [
		in peek = $< ifTrue: [in unCommand].	"Absorb <...><...>"
		(char _ in next) = $&
			ifTrue: [
				rest _ in upTo: $;.
				did _ out position.
				rest = 'lt' ifTrue: [out nextPut: $<].
				rest = 'gt' ifTrue: [out nextPut: $>].
				rest = 'amp' ifTrue: [out nextPut: $&].
				did = out position ifTrue: [
					self error: 'new HTML char encoding'.
					"Please add it to this code"]]
			ifFalse: [out nextPut: char].
		].
	^ out contents