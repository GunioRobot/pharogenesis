pickWorkingCopy
	| index |
	index _ (PopUpMenu labelArray: (self workingCopies collect: [:ea | ea packageName]))
				startUpWithCaption: 'Package:'.
	^ index = 0 ifFalse: [self workingCopies at: index]