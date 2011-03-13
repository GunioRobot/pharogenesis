value: anArgument
	| nArgs |
	numArgs ifNil:[numArgs _ selector numArgs].
	nArgs _ arguments ifNil:[0] ifNotNil:[arguments size].
	nArgs = numArgs ifTrue:[
		"Ignore extra argument"
		^self value].
	^arguments isNil
		ifTrue: [receiver perform: selector with: anArgument]
		ifFalse: [receiver perform: selector withArguments: (arguments copyWith: anArgument)]