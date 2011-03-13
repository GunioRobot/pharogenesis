openStandardWorkspace 
	"Open up a throwaway workspace with useful expressions in it.  1/22/96 sw"
	"Utilities openStandardWorkspace"

	Utilities
		openScratchWorkspaceLabeled: ('Useful Expressions ', Date today printString)
		contents: self standardWorkspaceContents.
