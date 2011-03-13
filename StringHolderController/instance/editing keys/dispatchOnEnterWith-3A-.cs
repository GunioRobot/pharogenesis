dispatchOnEnterWith: typeAheadStream
	"Enter key hit.  Treat is as an 'accept', viz a synonym for cmd-s.  If cmd key is down, treat is as a synonym for print-it.  2/7/96 sw.
	2/29/96 sw: fixed erratic behavior in the cmd-key-down case -- was not always giving the 'select-line-first' behavior when the selection was empty."

	sensor keyboard.  "consume enter key"
	sensor commandKeyPressed
		ifTrue:
			[self printIt.]
		ifFalse: 
			[self closeTypeIn: typeAheadStream.
			self accept].
	^ true