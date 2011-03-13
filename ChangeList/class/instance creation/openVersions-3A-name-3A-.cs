openVersions: aChangeList name: aString 
	"Open a standard system view for the changeList with a normal ListView"
	^ self open: aChangeList name: aString
		withListView: ListView new