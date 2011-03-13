selectedMessage
	"Answer a copy of the source code for the selected message."

	| class selector method tempNames |
	contents == nil ifFalse: [^ contents copy].
	class _ self selectedClassOrMetaClass.
	selector _ self selectedMessageName.
	method _ class compiledMethodAt: selector ifAbsent: [
		^ ''].	"method deleted while in another project"
	currentCompiledMethod _ method.

	(Sensor controlKeyPressed
		or: [method fileIndex > 0 and: [(SourceFiles at: method fileIndex) == nil]])
		ifTrue:
		["Emergency or no source file -- decompile without temp names"
		contents _ (class decompilerClass new decompile: selector in: class method: method)
			decompileString.
		contents _ contents asText makeSelectorBoldIn: class.
		^ contents copy].

	Sensor leftShiftDown ifTrue:
		["Special request to decompile -- get temps from source file"
		tempNames _ (class compilerClass new
						parse: method getSourceFromFile asString in: class notifying: nil)
						tempNames.
		contents _ ((class decompilerClass new withTempNames: tempNames)
				decompile: selector in: class method: method) decompileString.
		contents _ contents asText makeSelectorBoldIn: class.
		^ contents copy].

	self showComment
		ifFalse:
			[contents _ class sourceCodeAt: selector.
			self validateMessageSource: selector.

			Preferences browseWithPrettyPrint ifTrue:
				[contents _ class compilerClass new
					format: contents in: class notifying: nil decorated: Preferences colorWhenPrettyPrinting].
			self showDiffs ifTrue:
				[contents _ self diffFromPriorSourceFor: contents].

			contents _ contents asText makeSelectorBoldIn: class]
		ifTrue:
			[contents _ self commentContents].
	^ contents copy