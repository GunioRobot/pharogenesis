decompiledSourceIntoContentsWithTempNames: showTempNames 
	"Obtain a source string by decompiling the method's code, and place 
	that source string into my contents.
	Also return the string.
	Get temps from source file if showTempNames is true."

	| tempNames class selector method |
	class := self selectedClassOrMetaClass.
	selector := self selectedMessageName.
	"Was method deleted while in another project?"
	method := class compiledMethodAt: selector ifAbsent: [^ ''].

	currentCompiledMethod := method.
	(showTempNames not
			or: [method fileIndex > 0
					and: [(SourceFiles at: method fileIndex) isNil]])
		ifTrue: [
			"Emergency or no source file -- decompile without temp names "
			contents := (class decompilerClass new
						decompile: selector
						in: class
						method: method) decompileString]
		ifFalse: [tempNames := (class compilerClass new
						parse: method getSourceFromFile asString
						in: class
						notifying: nil) tempNames.
			contents := ((class decompilerClass new withTempNames: tempNames)
						decompile: selector
						in: class
						method: method) decompileString].
	contents := contents asText makeSelectorBoldIn: class.
	^ contents copy