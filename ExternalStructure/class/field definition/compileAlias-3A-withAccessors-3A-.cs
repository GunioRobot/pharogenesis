compileAlias: spec withAccessors: aBool
	"Define all the fields in the receiver.
	Return the newly compiled spec."
	| fieldName fieldType isPointerField externalType |
	fieldName _ spec first.
	fieldType _ spec second.
	isPointerField _ fieldType last = $*.
	fieldType _ fieldType copyWithout: $*.
	externalType _ ExternalType atomicTypeNamed: fieldType.
	externalType == nil ifTrue:["non-atomic"
		Symbol hasInterned: fieldType ifTrue:[:sym|
			externalType _ ExternalType structTypeNamed: sym]].
	externalType == nil ifTrue:[
		Transcript show:'(', fieldType,' is void)'.
		externalType _ ExternalType void].
	isPointerField ifTrue:[externalType _ externalType asPointerType].
	(fieldName notNil and:[aBool]) ifTrue:[
		self defineAliasAccessorsFor: fieldName
			type: externalType].
	isPointerField 
		ifTrue:[compiledSpec _ WordArray with: 
					(ExternalType structureSpec bitOr: ExternalType pointerSpec)]
		ifFalse:[compiledSpec _ externalType compiledSpec].
	ExternalType noticeModificationOf: self.
	^compiledSpec