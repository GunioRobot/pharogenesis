fieldsFrom: aStream do: aBlock
	"Invoke the given block with each of the header fields from the given stream. The block arguments are the field name and value."

	| savedLine line s |
	savedLine _ MailDB readStringLineFrom: aStream.
	[aStream atEnd] whileFalse: [
		line _ savedLine.
		(line isEmpty) ifTrue: [^self].  "quit when we hit a blank line"
		[savedLine _ MailDB readStringLineFrom: aStream.
		 (savedLine size > 0) and: [savedLine first isSeparator]] whileTrue: [
			"lines starting with white space are continuation lines"
			s _ ReadStream on: savedLine.
			s skipSeparators; skip: -1.
			line _ line, s upToEnd].
		self reportField: line withBlanksTrimmed to: aBlock].

	"process final header line of a body-less message"
	(savedLine isEmpty) ifFalse: [self reportField: savedLine withBlanksTrimmed to: aBlock].
