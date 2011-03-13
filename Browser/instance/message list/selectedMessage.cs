selectedMessage
	"Answer a copy of the source code for the selected message selector."
	| class selector method tempNames |
	contents == nil ifFalse: [^ contents copy].
	class _ self selectedClassOrMetaClass.
	selector _ self selectedMessageName.
	method _ class compiledMethodAt: selector.

	(Sensor controlKeyPressed
		or: [method fileIndex > 0 and: [(SourceFiles at: method fileIndex) == nil]])
		ifTrue:
		["Emergency or no source file -- decompile without temp names"
		contents _ (class decompilerClass new decompile: selector in: class method: method)
			decompileString.
		^ contents copy].

	Sensor leftShiftDown ifTrue:
		["Special request to decompile -- get temps from source file"
		tempNames _ (class compilerClass new
						parse: method getSourceFromFile asString in: class notifying: nil)
						tempNames.
		contents _ ((class decompilerClass new withTempNames: tempNames)
				decompile: selector
				in: class
				method: method) decompileString.
		contents _ contents asText makeSelectorBoldIn: self selectedClassOrMetaClass.
		^ contents copy].

	contents _ class sourceCodeAt: selector.
	contents _ contents asText makeSelectorBoldIn: self selectedClassOrMetaClass.
	^ contents copy