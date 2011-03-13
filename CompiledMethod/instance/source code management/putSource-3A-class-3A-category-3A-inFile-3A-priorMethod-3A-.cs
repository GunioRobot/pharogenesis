putSource: sourceStr class: class category: catName
	inFile: fileIndex priorMethod: priorMethod 
	"Print an expression that is a message to the argument, class, asking the 
	class to accept the source code, sourceStr, as a method in category, 
	catName. This is part of the format for writing descriptions of methods 
	on files. If no sources are specified, i.e., SourceFile iEs nil, then do 
	nothing. If the fileIndex is 1, print on *.sources; if it is 2, print on 
	*.canges.  If priorMethod is not nil, then link this source to the prior
	method and supply the time and date for this definition."
	| file remoteString |
	file _ SourceFiles at: fileIndex.
	file == nil ifTrue: [^self].
	file setToEnd.
	class printCategoryChunk: catName on: file priorMethod: priorMethod.
	file cr.
	remoteString _ 
		RemoteString
			newString: sourceStr
			onFileNumber: fileIndex
			toFile: file.
	file nextChunkPut: ' '; flush.
	self setSourcePosition: remoteString position inFile: fileIndex