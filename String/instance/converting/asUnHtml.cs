asUnHtml
	"Strip out all Html stuff (commands in angle brackets <>) and convert
the characters &<> back to their real value.  Leave actual cr and tab as
they were in text."
	| in out char rest did |
	in := ReadStream on: self.
	out := WriteStream on: (String new: self size).
	[in atEnd] whileFalse:
		[in peek = $<
			ifTrue: [in unCommand] 	"Absorb <...><...>"
			ifFalse: [(char := in next) = $&
						ifTrue: [rest := in upTo: $;.
								did := out position.
								rest = 'lt' ifTrue: [out nextPut: $<].
								rest = 'gt' ifTrue: [out nextPut: $>].
								rest = 'amp' ifTrue: [out nextPut: $&].
								rest = 'deg' ifTrue: [out nextPut: $°].
								rest = 'quot' ifTrue: [out nextPut: $"].
								rest = 'nbsp' ifTrue: [out nextPut: Character space].
								did = out position ifTrue: [
									self error: 'unknown encoded HTML char'.
									"Please add it to this method"]]
						ifFalse: [out nextPut: char]].
		].
	^ out contents