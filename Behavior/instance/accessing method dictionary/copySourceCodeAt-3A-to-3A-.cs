copySourceCodeAt: selector to: aFileStream
	| code method dict |
	method _ methodDict at: selector.
	(Sensor leftShiftDown or: [(method copySourceTo: aFileStream) == false])
		ifTrue: [aFileStream nextChunkPut: (self decompilerClass new
					decompile: selector
					in: self
					method: method) decompileString]
