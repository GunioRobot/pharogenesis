selectedMessage
	"Answer a copy of the source code for the selected message selector."

	| class selector |
	class _ self selectedClassOrMetaClass.
	selector _ self selectedMessageName.
	contents _ class sourceCodeAt: selector.
	Preferences browseWithPrettyPrint ifTrue: [contents _ Compiler new
					format: contents
					in: class
					notifying: nil
					decorated: Preferences colorWhenPrettyPrinting].
	self showingAnyKindOfDiffs ifTrue:
		[contents _ self
			methodDiffFor: contents
			class: self selectedClass
			selector: self selectedMessageName
			meta: self metaClassIndicated].
	^ contents asText makeSelectorBoldIn: class