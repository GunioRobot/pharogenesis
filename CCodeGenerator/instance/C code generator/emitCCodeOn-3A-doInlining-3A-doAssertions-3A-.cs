emitCCodeOn: aStream doInlining: inlineFlag doAssertions: assertionFlag
	"Emit C code for all methods in the code base onto the given stream. All inlined method calls should already have been expanded."

	| verbose |
	"method preparation"
	verbose _ false.
	self prepareMethods.
	verbose ifTrue: [
		self printUnboundCallWarnings.
		self printUnboundVariableReferenceWarnings.
		Transcript cr.
	].
	assertionFlag ifFalse: [ self removeAssertions ].
	self doInlining: inlineFlag.

	"code generation"
	methods _ methods asSortedCollection: [ :m1 :m2 | m1 selector < m2 selector ].
	self emitCHeaderOn: aStream.
	self emitCVariablesOn: aStream.
	self emitCFunctionPrototypesOn: aStream.
'Writing Translated Code...'
displayProgressAt: Sensor cursorPoint
from: 0 to: methods size
during: [:bar |
	methods doWithIndex: [ :m :i | bar value: i.
		m emitCCodeOn: aStream generator: self.
]].