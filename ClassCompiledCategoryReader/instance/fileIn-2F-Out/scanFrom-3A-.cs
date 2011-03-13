scanFrom: aStream 
	"File in compiled methods from the stream, aStream. Much faster than
	 superclass method.  To save even more time, do not print the name and
	 category of the methods in the transcript view."
	| file string header byteCodes method mStrm scanner selector remoteString |
	file _ SourceFiles at: 2.
	file isNil ifFalse:
		[file setToEnd. class printCategoryChunk: category on: file. file cr].
	[string _ aStream nextChunk.
	 string size > 0]						"done when double terminators"
		whileTrue:
			[header _ string asNumber.
			byteCodes _ ByteArray fromHex: aStream nextChunk.
			method _ CompiledMethod
						newMethod: byteCodes size+3
						header: header.
			mStrm _ ReadWriteStream with: method.
			mStrm position: method initialPC - 1.
			mStrm nextPutAll: byteCodes.
			scanner _ Scanner new scan: (ReadStream on: aStream nextChunk).
			1 to: method numLiterals do:
				[:i |
				 method literalAt: i put:
					(class literalScannedAs: scanner nextLiteral notifying: nil)].
			selector _ aStream nextChunk asSymbol.
			file isNil ifFalse:
				[remoteString _ RemoteString new
					fromFile: aStream
					onFileNumber: 2
					toFile: file.
				 method setSourcePosition: remoteString position inFile: 2].
			NewMethods add:
				(Array with: class with: category with: selector with: method)].
	file isNil ifFalse: [file nextChunkPut: ' '; flush]