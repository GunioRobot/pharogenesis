nextPutFlagsDefinition: tricky on: file

	| ivars primitives prim |
	ivars _ #(activeFrame argumentCount stackPointer successFlag).
	"Sanity check"
	self assertVars: ivars subsumeAll: tricky.
	primitives _ Interpreter primitiveTable.
	file nextPutAll: 'unsigned char primitiveFlags['; print: primitives size + 1; nextPutAll: ']= {'; cr.
	'scanning for GC reachability...'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: primitives size - 1
		during: [:bar |
			0 to: primitives size - 1 do: [:index |
				bar value: index.
				prim _ primitives at: index + 1.
				file nextPutAll: '  0'.
				prim == #primitiveFail
					ifTrue: [file nextPutAll: ' | PrimitiveFailBit']
					ifFalse:
						[(tricky includesKey: prim)
								ifTrue: [(tricky at: prim) do:
											[:var | file nextPutAll: ' | '; nextPutAll: var capitalized; nextPutAll: 'Bit']]
								ifFalse: [file nextPutAll: ' | IntrinsicPrimBit'].
						 (self gcReachableFrom: prim) ifTrue: [file nextPutAll: ' | ActiveFrameBit']].
				file nextPutAll: ',	// '; nextPutAll: prim; cr]].
	file nextPutAll: '  0
};'; cr.