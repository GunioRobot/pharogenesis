readContentsBrief: brevity
	"Read the contents of the receiver's selected file."
	listIndex = 0
		ifTrue: [^self defaultContents]
		ifFalse: [^ super readContentsBrief: brevity]