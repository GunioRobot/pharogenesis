initialize
	"initialize the state of the receiver"
	super initialize.
	""
	applyToWholeText _ true.
	myTarget
		ifNil: [""
			myTarget _ TextMorph new openInWorld.
			myTarget contents: ''].

	activeTextMorph _ myTarget copy.
	activeTextMorph extent: 300 @ 100;	 
			 releaseCachedState.
	thingsToRevert
		at: #wrapFlag: put: myTarget isWrapped;
		 at: #autoFit: put: myTarget isAutoFit;
		 at: #margins: put: myTarget margins;
		at: #extent: put: myTarget extent.
	self rebuild