fontForName

	| pickem |
	pickem _ 3.

	pickem = 1 ifTrue: [
		^(((TextStyle named: #Helvetica) ifNil: [TextStyle default]) fontOfSize: 13) emphasized: 1.
	].
	pickem = 2 ifTrue: [
		^(((TextStyle named: #Palatino) ifNil: [TextStyle default]) fontOfSize: 12) emphasized: 1.
	].
	^((TextStyle default) fontAt: 1) emphasized: 1
