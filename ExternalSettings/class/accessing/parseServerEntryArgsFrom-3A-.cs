parseServerEntryArgsFrom: stream
	"Args are in the form <argName>: <argValueString> delimited by end of line.
	It's not a very robust format and should be replaced by something like XML later.
	But it avoids evaluating the entries for security reasons."

	| entries lineStream entryName entryValue |
	entries _ Dictionary new.
	stream skipSeparators.
	[stream atEnd]
		whileFalse: [
			lineStream _ ReadStream on: stream nextLine.
			entryName _ lineStream upTo: $:.
			lineStream skipSeparators.
			entryValue _ lineStream upToEnd.
			(entryName isEmptyOrNil 
				or: [entryValue isEmptyOrNil])
				ifFalse: [entries at: entryName put: entryValue withoutTrailingBlanks].
			stream skipSeparators].
	^entries