nextPut: aCharacter toStream: aStream

	| v low high |
	(self useByteOrderMark and: [byteOrderMarkDone isNil]) ifTrue: [
		self next16BitValue: (16rFEFF) toStream: aStream.
		byteOrderMarkDone _ true.
	].

	v _ aCharacter charCode.
	v > 16rFFFF ifFalse: [
		self next16BitValue: v toStream: aStream.
		^ self.
	] ifTrue: [
		v _ v - 16r10000.
		low _ (v \\ 16r400) + 16rDC00.
		high _ (v // 16r400) + 16rD800.
		self next16BitValue: high toStream: aStream.
		self next16BitValue: low toStream: aStream.
	]