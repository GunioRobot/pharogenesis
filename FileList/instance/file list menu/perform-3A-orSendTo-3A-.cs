perform: selector orSendTo: otherTarget
	"Selector was just chosen from a menu by a user.  If can respond, then perform it on myself.  If not, send it to otherTarget, presumably the editPane from which the menu was invoked." 

	(#(get getHex browseChanges
sortByDate sortBySize sortByName
fileInSelection fileIntoNewChangeSet browseChanges copyName
openImageInWindow importImage playMidiFile
renameFile deleteFile addNewFile putUpdate) includes: selector)
		ifTrue: [^ self perform: selector]
		ifFalse: [^ super perform: selector orSendTo: otherTarget]