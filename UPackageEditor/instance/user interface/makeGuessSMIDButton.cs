makeGuessSMIDButton
	^(UInterfaceUtilities makeButtonWithAction: #guessSqueakMapID  andLabel: 'guess' for: self)
		hResizing: #shrinkWrap