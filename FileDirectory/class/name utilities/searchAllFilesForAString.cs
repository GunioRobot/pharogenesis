searchAllFilesForAString

	"Prompt the user for a search string, and a starting directory. Search the contents of all files in the starting directory and its subdirectories for the search string (case-insensitive search.)
	List the paths of files in which it is found on the Transcript.
	By Stewart MacLean 5/00; subsequently moved to FileDirectory class-side, and refactored to call FileDirectory.filesContaining:caseSensitive:"

	| searchString dir |

	searchString _ FillInTheBlankMorph request: 'Enter search string'.
	searchString isEmpty ifTrue: [^nil].
	Transcript cr; show: 'Searching for ', searchString printString, ' ...'.
	(dir _ PluggableFileList getFolderDialog open) ifNotNil:
		[(dir filesContaining: searchString caseSensitive: false) do:
				[:pathname | Transcript cr; show: pathname]].
	Transcript cr; show: 'Finished searching for ', searchString printString

	"FileDirectory searchAllFilesForAString"