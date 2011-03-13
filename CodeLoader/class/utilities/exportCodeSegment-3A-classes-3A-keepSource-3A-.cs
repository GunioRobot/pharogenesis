exportCodeSegment: exportName classes: aClassList keepSource: keepSources

	"Code for writing out a specific category of classes as an external image segment.  Perhaps this should be a method."

	| is oldMethods newMethods m oldCodeString argsAndTemps classList symbolHolder fileName |
	keepSources
		ifTrue: [
			self confirm: 'We are going to abandon sources.
Quit without saving after this has run.' orCancel: [^self]].

	classList _ aClassList asArray.

	"Strong pointers to symbols"
	symbolHolder := Symbol allInstances.

	oldMethods _ OrderedCollection new: classList size * 150.
	newMethods _ OrderedCollection new: classList size * 150.
	keepSources
		ifTrue: [
			classList do: [:cl |
				cl selectors do:
					[:selector |
					m _ cl compiledMethodAt: selector.
					m fileIndex > 0 ifTrue:
						[oldCodeString _ cl sourceCodeAt: selector.
						argsAndTemps _ (cl compilerClass new
							parse: oldCodeString in: cl notifying: nil) tempNames.
						oldMethods addLast: m.
						newMethods addLast: (m copyWithTempNames: argsAndTemps)]]]].
	oldMethods asArray elementsExchangeIdentityWith: newMethods asArray.
	oldMethods _ newMethods _ m _ oldCodeString _ argsAndTemps _ nil.

	Smalltalk garbageCollect.
	is _ ImageSegment new copyFromRootsForExport: classList.	"Classes and MetaClasses"

	fileName _ FileDirectory fileName: exportName extension: ImageSegment fileExtension.
	is writeForExport: fileName.
	self compressFileNamed: fileName

