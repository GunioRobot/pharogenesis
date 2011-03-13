= method
	| myLits otherLits |
	"Answer whether the receiver implements the same code as the 
	argument, method."
	(method isKindOf: CompiledMethod) ifFalse: [^false].
	self size = method size ifFalse: [^false].
	self header = method header ifFalse: [^false].
	self initialPC to: self endPC do:
		[:i | (self at: i) = (method at: i) ifFalse: [^false]].
	(myLits := self literals allButLast: 2) = (otherLits := method literals allButLast: 2) ifFalse:
		[myLits size = otherLits size ifFalse: [^ false].
		"Dont bother checking FFI and named primitives"
		(#(117 120) includes: self primitive) ifTrue: [^ true].
		myLits with: otherLits do: [:lit1 :lit2 | 
			lit1 = lit2 ifFalse: [
				lit1 isFloat 
					ifTrue: ["Floats match if values are close, due to roundoff error."
						(lit1 closeTo: lit2) ifFalse: [^ false]] 
					ifFalse: ["any other discrepancy is a failure"
						^ false]]]].
	^ true