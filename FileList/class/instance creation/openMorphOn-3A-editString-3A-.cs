openMorphOn: aFileStream editString: editString 
	"Open a morphic view of a FileList on the default directory."
	| fileModel window fileContentsView |

	fileModel _ FileList new setFileStream: aFileStream.	"closes the stream"
	window _ (SystemWindow labelled: aFileStream fullName) model: fileModel.

	window addMorph: (fileContentsView _ PluggableTextMorph on: fileModel 
			text: #contents accept: #put:
			readSelection: #contentsSelection 
			menu: #fileContentsMenu:shifted:)
		frame: (0@0 corner: 1@1).
	editString ifNotNil: [fileContentsView editString: editString.
			fileContentsView hasUnacceptedEdits: true].

	window openInWorld