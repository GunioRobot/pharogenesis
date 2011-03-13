putSource: sourceStr fromParseNode: methodNode inFile: fileIndex withPreamble: preambleBlock
	"Store the source code for the receiver on an external file.
	If no sources are available, i.e., SourceFile is nil, then store
	temp names for decompilation at the end of the method.
	If the fileIndex is 1, print on *.sources;  if it is 2, print on *.changes,
	in each case, storing a 4-byte source code pointer at the method end."

	| file remoteString  st80str |
	(SourceFiles == nil or: [(file _ SourceFiles at: fileIndex) == nil]) ifTrue:
		[^ self become: (self copyWithTempNames: methodNode tempNames)].

	Smalltalk assureStartupStampLogged.
	file setToEnd.

	preambleBlock value: file.  "Write the preamble"
	(methodNode isKindOf: DialectMethodNode)
		ifTrue:
		["This source was parsed from an alternate syntax.
		We must convert to ST80 before logging it."
		st80str _ (DialectStream dialect: #ST80 contents: [:strm | methodNode printOn: strm])
						asString.
		remoteString _ RemoteString newString: st80str
						onFileNumber: fileIndex toFile: file]
		ifFalse:
		[remoteString _ RemoteString newString: sourceStr
						onFileNumber: fileIndex toFile: file].

	file nextChunkPut: ' '; flush.
	self checkOKToAdd: sourceStr size at: remoteString position.
	self setSourcePosition: remoteString position inFile: fileIndex