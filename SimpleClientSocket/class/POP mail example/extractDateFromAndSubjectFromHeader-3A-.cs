extractDateFromAndSubjectFromHeader: headerString

	| date from subject s lineBuf c line i |
	date _ from _ subject _ ''.
	s _ ReadStream on: headerString.
	lineBuf _ WriteStream on: ''.
	[s atEnd] whileFalse: [
		c _ s next.
		c = CR
			ifTrue: [
				line _ lineBuf contents.
				(line beginsWith: 'Date: ')	ifTrue: [date _ line copyFrom: 7 to: line size].
				(line beginsWith: 'From: ')	ifTrue: [from _ line copyFrom: 7 to: line size].
				(line beginsWith: 'Subject: ')	ifTrue: [subject _ line copyFrom: 10 to: line size].
				lineBuf _ WriteStream on: '']
			ifFalse: [lineBuf nextPut: c]].

	i _ date indexOf: $' ifAbsent: [0].
	date _ date copyFrom: i + 1 to: date size.
	^ (self simpleDateString: date), ', ', from, ':
  ', subject
