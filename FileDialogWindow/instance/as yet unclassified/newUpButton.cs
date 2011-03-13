newUpButton
	"Answer a new up one directory level button."

	^self 
		newButtonFor: self
		getState: nil
		action: #selectParentDirectory
		arguments: nil
		getEnabled: #hasParentDirectory
		labelForm: MenuIcons smallUndoIcon
		help: 'Press to switch to the parent of the current directory' translated