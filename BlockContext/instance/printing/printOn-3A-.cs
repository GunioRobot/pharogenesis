printOn: aStream
	| blockString truncatedBlockString |

	home == nil ifTrue: [^aStream nextPutAll: 'a BlockContext with home=nil'].
	aStream nextPutAll: '[] in '.
	super printOn: aStream.
	aStream nextPutAll: ' '.
	blockString _ ((self decompile ifNil: ['--source missing--']) printString
						replaceAll: Character cr with: Character space)
							replaceAll: Character tab with: Character space.
	truncatedBlockString _ blockString truncateWithElipsisTo: 80.
	truncatedBlockString size < blockString size ifTrue:
		[truncatedBlockString _ truncatedBlockString, ']}'].
	aStream nextPutAll: truncatedBlockString.
