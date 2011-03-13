fileNameFormattedFrom: entry sizePad: sizePad 
	"entry is a 5-element array of the form:
		(name creationTime modificationTime dirFlag fileSize)"

	"If the short file list flag is false, we send this on to the superclass."

	| nameStr |
	showShortFileNames 
		ifFalse: [^super fileNameFormattedFrom: entry sizePad: sizePad].

	"Otherwise, just show the name of the file in the file list."
	nameStr := (entry at: 4) 
				ifTrue: [entry first , self folderString]
				ifFalse: [entry first].
	^nameStr