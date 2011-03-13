spawnWorkspace
	| toUse |
	self selectLine.
	toUse _ self selection asString.
	toUse size > 0 ifFalse:
		[toUse _ paragraph text string.
		toUse size > 0 ifFalse: [^ self flash]].
	"NB: BrowserCodeController's version does a cancel here"
	self controlTerminate.
	Utilities openScratchWorkspaceLabeled: 'Untitled' contents: toUse.
	self controlInitialize.
