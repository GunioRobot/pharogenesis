printExecutionState
	| lo hi byte |
	^String streamContents: [:str |
		str nextPutAll: '			{ '.
		lo _ self cachedFramePointerAt: activeCachedContext.
		hi _ localSP.
		lo to: hi by: 4 do: [:ptr |
			ptr == lo ifFalse: [str nextPutAll: ' , '].
			str nextPutAll: (self shortPrint: (self longAt: ptr))].
		str nextPutAll: ' }'; crtab; tab.
		(self instructionIndex: localIP - 4 "instr already fetched") printOn: str.
		byte _ self byteAt: (self internalMethod + BaseHeaderSize + (self instructionIndex: localIP) - "0-rel" 1).
		str tab; nextPutAll: byte hex; tab; nextPutAll: (Interpreter bytecodeTable at: byte + 1).
	].