copyPlatformFilesFor: plugin internal: aBoolean
	| srcDir targetDir |
	[srcDir _ self platformPluginsDirectory directoryNamed: plugin moduleName.
	targetDir _ aBoolean ifTrue:[self internalPluginsDirectoryFor: plugin]
					ifFalse:[self externalPluginsDirectoryFor: plugin].
	logger show: 'Copy any platform files from: ' , srcDir printString , ' to ' , targetDir printString; cr.
	self copyFilesFromSourceDirectory: srcDir toTargetDirectory: targetDir]
		on: FileStreamException
		do: ["If any file related exceptions get here, we've had some problem, probably path of permissions. Raise the general exception"
			^ self couldNotFindPlatformFilesFor: plugin]