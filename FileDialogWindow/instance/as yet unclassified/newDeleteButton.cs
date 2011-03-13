newDeleteButton
	"Answer a new delete button."

	^self 
		newButtonFor: self
		getState: nil
		action: #deleteFileOrDirectory
		arguments: nil
		getEnabled: #hasSelectedFileOrDirectory
		labelForm:  MenuIcons smallDeleteIcon
		help: 'Press to delete the selected file or directory' translated