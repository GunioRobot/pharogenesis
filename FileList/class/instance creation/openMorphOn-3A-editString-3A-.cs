openMorphOn: aFileStream editString: editString 
	"Open a morphic view of a FileList on the given file."
	| fileModel window fileContentsView |

	fileModel := FileList new setFileStream: aFileStream.	"closes the stream"
	window := (SystemWindow labelled: aFileStream fullName) model: fileModel.

	window addMorph: (fileContentsView := PluggableTextMorph on: fileModel 
			text: #contents accept: #put:
			readSelection: #contentsSelection 
			menu: #fileContentsMenu:shifted:)
		frame: (0@0 corner: 1@1).
	editString ifNotNil: [fileContentsView editString: editString.
			fileContentsView hasUnacceptedEdits: true].

	^ window