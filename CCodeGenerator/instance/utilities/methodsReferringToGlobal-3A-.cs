methodsReferringToGlobal: v
	"Return a collection of methods that refer to the given global variable."

	| out |
	out _ OrderedCollection new.
	methods associationsDo: [ :assoc |
		(assoc value freeVariableReferences includes: v) ifTrue: [
			out add: assoc key.
		].
	].
	^ out