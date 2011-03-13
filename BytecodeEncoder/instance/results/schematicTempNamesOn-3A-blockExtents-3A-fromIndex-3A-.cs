schematicTempNamesOn: aStream blockExtents: blockExtents fromIndex: startIndex
	"Print the locals in the blockExtent startIndex, recursing to print any locals in nested blockExtents.
	 Answer the index of the last blockExtent printed."
	| blockExtent subsequentIndex |
	blockExtent := blockExtents at: startIndex.
	((blockExtentsToLocals at: blockExtent) reject: [:local| local isRemote]) do:
		[:local|
		local isIndirectTempVector
			ifTrue: [local remoteTemps do:
						[:remoteLocal| aStream nextPut: remoteLocal key]]
			ifFalse: [aStream nextPut: local key]].
	subsequentIndex := startIndex + 1.
	[subsequentIndex <= blockExtents size
	 and: [(blockExtents at: subsequentIndex) last < blockExtent last]] whileTrue:
		[aStream nextPut: (Array streamContents:
				[:nestedTempStream|
				subsequentIndex := self schematicTempNamesOn: nestedTempStream
										blockExtents: blockExtents
										fromIndex: subsequentIndex])].
	^subsequentIndex