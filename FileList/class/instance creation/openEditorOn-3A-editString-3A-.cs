openEditorOn: aFileStream editString: editString
	"Open an editor on the given FileStream."

	| fileModel topView fileContentsView |
	Smalltalk isMorphic ifTrue: [^ (self openMorphOn: aFileStream editString: editString) openInWorld].

	fileModel _ FileList new setFileStream: aFileStream.	"closes the stream"
	topView _ StandardSystemView new.
	topView
		model: fileModel;
		label: aFileStream fullName;
		minimumSize: 180@120.
	topView borderWidth: 1.

	fileContentsView _ PluggableTextView on: fileModel 
		text: #contents accept: #put:
		readSelection: #contentsSelection menu: #fileContentsMenu:shifted:.
	fileContentsView window: (0@0 extent: 180@120).
	topView addSubView: fileContentsView.
	editString ifNotNil: [fileContentsView editString: editString.
			fileContentsView hasUnacceptedEdits: true].

	topView controller open.
