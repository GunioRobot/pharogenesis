selectedBytecodes
	"Compile the source code for the selected message selector and extract and return
	the bytecode listing."
	| class selector |
	class _ self selectedClassOrMetaClass.
	selector _ self selectedMessageName.
	contents _ class sourceCodeAt: selector.
	contents _ Compiler new
					parse: contents
					in: class
					notifying: nil.
	contents _ contents generate: #(0 0 0 0).
	^ contents symbolic asText