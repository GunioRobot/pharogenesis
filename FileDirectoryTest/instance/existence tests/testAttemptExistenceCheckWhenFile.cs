testAttemptExistenceCheckWhenFile
"How should a FileDirectory instance respond with an existent file name?"
| directory |
FileDirectory default
				forceNewFileNamed: 'aTestFile'.
directory := FileDirectory default
				directoryNamed: 'aTestFile'.
self shouldnt: [directory exists]
	description: 'Files are not directories.'.