spaceForInstancesOf: aClass withInstanceCount: instCount
	"Answer the number of bytes consumed by all instances of the given class, including their object headers."

	| isCompact instVarBytes bytesPerElement contentBytes headerBytes total |
	instCount = 0 ifTrue: [^ 0].
	isCompact := aClass indexIfCompact > 0.
	instVarBytes := aClass instSize * 4.
	aClass isVariable
		ifTrue: [
			bytesPerElement := aClass isBytes ifTrue: [1] ifFalse: [4].
			total := 0.
			aClass allInstancesDo: [:inst |
				contentBytes := instVarBytes + (inst size * bytesPerElement).
				headerBytes :=
					contentBytes > 255
						ifTrue: [12]
						ifFalse: [isCompact ifTrue: [4] ifFalse: [8]].
				total := total + headerBytes + contentBytes].
			^ total]
		ifFalse: [
			headerBytes :=
				instVarBytes > 255
					ifTrue: [12]
					ifFalse: [isCompact ifTrue: [4] ifFalse: [8]].
			^ instCount * (headerBytes + instVarBytes)].
