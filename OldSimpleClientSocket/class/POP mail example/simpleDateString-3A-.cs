simpleDateString: dateString

	| s |
	s _ ReadStream on: dateString.
	s skipTo: $,.  "scan thru first comma"
	s atEnd ifTrue: [s reset].  "no comma found; reset s"
	s skipSeparators.
	^ (Date readFrom: s) mmddyyyy
