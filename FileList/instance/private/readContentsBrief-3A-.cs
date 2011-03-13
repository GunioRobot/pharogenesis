readContentsBrief: brevity
	"Read the contents of the receiver's selected file."
	listIndex = 0
		ifTrue: [^'']
		ifFalse: [^ super readContentsBrief: brevity]