compileFields: specArray withAccessors: aBool 
	"Define all the fields in the receiver. 
	Return the newly compiled spec."
	| fieldName fieldType isPointerField externalType byteOffset typeSize typeSpec selfRefering |
	(specArray size > 0
			and: [specArray first class ~~ Array])
		ifTrue: [^ self compileAlias: specArray withAccessors: aBool].
	byteOffset _ 1.
	typeSpec _ WriteStream
				on: (WordArray new: 10).
	typeSpec nextPut: FFIFlagStructure.
	"dummy for size"
	specArray
		do: [:spec | 
			fieldName _ spec first.
			fieldType _ spec second.
			isPointerField _ fieldType last = $*.
			fieldType _ (fieldType findTokens: ' *') first.
			externalType _ ExternalType atomicTypeNamed: fieldType.
			selfRefering _ externalType == nil and: fieldType = self asString and: isPointerField.
			selfRefering
				ifTrue: [externalType _ ExternalType void asPointerType]
				ifFalse:
			[externalType == nil
				ifTrue: ["non-atomic"
					Symbol
						hasInterned: fieldType
						ifTrue: [:sym | externalType _ ExternalType structTypeNamed: sym]].
			externalType == nil
				ifTrue: [Transcript show: '(' , fieldType , ' is void)'.
					externalType _ ExternalType void].
			isPointerField
				ifTrue: [externalType _ externalType asPointerType]].
			typeSize _ externalType byteSize.
			spec size > 2
				ifTrue: ["extra size"
					spec third < typeSize
						ifTrue: [^ self error: 'Explicit type size is less than expected'].
					typeSize _ spec third].
			(fieldName notNil and: [aBool])
				ifTrue: [self
						defineFieldAccessorsFor: fieldName
						startingAt: byteOffset
						type: externalType].
			typeSpec
				nextPutAll: (externalType embeddedSpecWithSize: typeSize).
			byteOffset _ byteOffset + typeSize].
	compiledSpec _ typeSpec contents.
	compiledSpec
		at: 1
		put: (byteOffset - 1 bitOr: FFIFlagStructure).
	ExternalType noticeModificationOf: self.
	^ compiledSpec