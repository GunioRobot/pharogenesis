newNewDirectoryButton
	"Answer a new 'new directory' button."

	^self 
		newButtonFor: self
		getState: nil
		action: #newDirectory
		arguments: nil
		getEnabled: nil
		labelForm: MenuIcons smallOpenIcon
		help: 'Press to create a new directory within the current directory' translated