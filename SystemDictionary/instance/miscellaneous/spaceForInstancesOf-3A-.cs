spaceForInstancesOf: aClass
	"Answer the number of bytes consumed by all instances of the given class, including thier object headers."

	| instCount isCompact instVarBytes bytesPerElement contentBytes headerBytes total |
	instCount _ aClass instanceCount.
	instCount = 0 ifTrue: [^ 0].
	isCompact _ aClass indexIfCompact > 0.
	instVarBytes _ aClass instSize * 4.
	aClass isVariable
		ifTrue: [
			bytesPerElement _ aClass isBytes ifTrue: [1] ifFalse: [4].
			total _ 0.
			aClass allInstancesDo: [:inst |
				contentBytes _ instVarBytes + (inst size * bytesPerElement).
				headerBytes _
					contentBytes > 255
						ifTrue: [12]
						ifFalse: [isCompact ifTrue: [4] ifFalse: [8]].
				total _ total + headerBytes + contentBytes].
			^ total]
		ifFalse: [
			headerBytes _
				instVarBytes > 255
					ifTrue: [12]
					ifFalse: [isCompact ifTrue: [4] ifFalse: [8]].
			^ instCount * (headerBytes + instVarBytes)].
