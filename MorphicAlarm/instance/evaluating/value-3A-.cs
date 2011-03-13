value: anArgument
	| nArgs |
	numArgs ifNil:[numArgs := selector numArgs].
	nArgs := arguments ifNil:[0] ifNotNil:[arguments size].
	nArgs = numArgs ifTrue:[
		"Ignore extra argument"
		^self value].
	^arguments isNil
		ifTrue: [receiver perform: selector with: anArgument]
		ifFalse: [receiver perform: selector withArguments: (arguments copyWith: anArgument)]