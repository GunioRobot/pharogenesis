selectedMessage
	"Answer the source code of the currently selected context."
	contents _ [self selectedContext sourceCode] ifError: [ :err :rcvr |
		'ERROR
"',(err reject: [ :each | each == $"]),'"'
	].
	Preferences browseWithPrettyPrint ifTrue: [contents _ self selectedClass compilerClass new
					format: contents
					in: self selectedClass
					notifying: nil
					decorated: Preferences colorWhenPrettyPrinting].
	^ contents _ contents asText makeSelectorBoldIn: self selectedClass