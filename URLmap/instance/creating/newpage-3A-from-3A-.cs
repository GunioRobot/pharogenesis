newpage: label from: peer
	| newpage newfile |
		newpage _ SwikiPage new. 
		self at: label put: newpage. 
		newfile _ pages size printString.
		newpage address: peer.
		newpage date: (Date today).
		newpage coreID: newfile.
		newpage name: label.
		newpage file: ((ServerAction serverDirectory), 
			directory, (ServerAction pathSeparator), newfile).
		newpage text: 'Describe ',label,' here'.
		newpage map: self.
		newpage url: (action name),'.',newfile.
	^newpage
