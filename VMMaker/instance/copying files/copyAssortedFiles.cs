copyAssortedFiles
	"copy any miscellaneous files/dirs from the cross-platformDirectory/misc/ToCopy -  
	general readme files etc, then from the platform specific directory/misc/ToCopy - makefiles, 
	utils etc that have to be copied."
	| srcDir |
	"Is there a crossPlatformDirectory subdirectory called 'misc'?"
	(self crossPlatformDirectory directoryExists: 'misc')
		ifTrue: [srcDir _ self crossPlatformDirectory directoryNamed: 'misc'.
			"Is there a subdirectory called 'ToCopy' ?"
			(srcDir directoryExists: 'ToCopy') ifTrue:[
				srcDir _ srcDir directoryNamed: 'ToCopy'.
				self copyFilesFromSourceDirectory: srcDir toTargetDirectory: self sourceDirectory]].
	"Is there a platformDirectory subdirectory called 'misc'?"
	(self platformDirectory directoryExists: 'misc')
		ifTrue: [srcDir _ self platformDirectory directoryNamed: 'misc'.
			"Is there a subdirectory called 'ToCopy' ?"
			(srcDir directoryExists: 'ToCopy') ifTrue:[
				srcDir _ srcDir directoryNamed: 'ToCopy'.
				self copyFilesFromSourceDirectory: srcDir toTargetDirectory: self sourceDirectory]]