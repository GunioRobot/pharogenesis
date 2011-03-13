newpage: label from: peer
	| newpage newfile |
	newfile _ ((pages inject: 0 into: [:max :p | 
		p coreID asNumber > max ifTrue: [p coreID asNumber] 
				ifFalse: [max]]) + 1) printString.
	newpage _ SwikiPage new.
	self at: label put: newpage.
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
