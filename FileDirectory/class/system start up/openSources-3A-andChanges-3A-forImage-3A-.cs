openSources: sourcesName andChanges: changesName forImage: imageName
	"Initialize the default directory to the image directory and open the sources and changes files, if possible. Look for the changes file in image directory. Look for the system sources (or an alias to it) first in the VM directory, then in the image directory. Open the changes and sources files and install them in SourceFiles."
	"Note: SourcesName and imageName are full paths; changesName is a local name."

	| sources changes sourceAlias msg localSourcesName |
	msg _
'Squeak cannot locate &fileRef.
Please check that the file is named properly and is in the
same directory as this image.  Further explanation can found
in the startup window, ''How Squeak Finds Source Code''.'.

	self setDefaultDirectoryFrom: imageName.
	sources _ changes _ nil.

	"look for the sources file or an alias to it in the VM's directory"
	(DefaultDirectory fileExists: sourcesName)
		ifTrue: [sources _ DefaultDirectory readOnlyFileNamed: sourcesName]
		ifFalse: [
			"look for an un-renamed Macintosh alias to the sources file"
			sourceAlias _ sourcesName, ' alias'.
			(DefaultDirectory fileExists: sourceAlias)
				ifTrue: [sources _ DefaultDirectory readOnlyFileNamed: sourceAlias]].

	sources ifNil: [
		"look for the sources file or an alias to it in the image directory"
		localSourcesName _ FileDirectory localNameFor: sourcesName.
		(DefaultDirectory fileExists: localSourcesName)
			ifTrue: [sources _ DefaultDirectory readOnlyFileNamed: localSourcesName]
			ifFalse: [
				"look for an un-renamed Macintosh alias to the sources file"
				sourceAlias _ localSourcesName, ' alias'.
				(DefaultDirectory fileExists: sourceAlias)
					ifTrue: [sources _ DefaultDirectory readOnlyFileNamed: sourceAlias]]].

	(DefaultDirectory fileExists: changesName)
		ifTrue: [changes _ DefaultDirectory oldFileNamed: changesName].

	((sources == nil) and: [Preferences valueOfFlag: #warnIfNoSourcesFile]) ifTrue: [
		PopUpMenu notify:
			(msg copyReplaceAll: '&fileRef' with: 'the sources file named ' , sourcesName)].

	((changes == nil) and: [Preferences valueOfFlag: #warnIfNoChangesFile]) ifTrue: [
		PopUpMenu notify:
			(msg copyReplaceAll: '&fileRef' with: 'the changes file named ' , changesName)].

	SourceFiles _ Array with: sources with: changes.
