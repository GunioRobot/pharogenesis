processAssortedFiles
	"See the comment in VMMaker> processAssortedFiles first.
	This version of the method will copy any miscellaneous files/dirs from the cross-platformDirectory -  readme files etc, then from the platform specific directory - makefiles, utils etc. "
	 
	| srcDir |
	"Is there a crossPlatformDirectory subdirectory called 'misc'?"
	(self crossPlatformDirectory directoryExists: 'misc')
		ifTrue: [srcDir _ self crossPlatformDirectory directoryNamed: 'misc'.
			self copyFilesFromSourceDirectory: srcDir toTargetDirectory: self sourceDirectory].
	"Is there a platformDirectory subdirectory called 'misc'?"
	(self platformDirectory directoryExists: 'misc')
		ifTrue: [srcDir _ self platformDirectory directoryNamed: 'misc'.
			self copyFilesFromSourceDirectory: srcDir toTargetDirectory: self sourceDirectory].

	"Now copy any files that are always copied for all platforms"
	super processAssortedFiles
