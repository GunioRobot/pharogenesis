method9
	"Test conditional code generation."

	true ifTrue: [^ 1].
	false ifTrue: [^ 'should not be generated'].

	true ifFalse: [^ 'should not be generated'].
	false ifFalse: [^ 2].

	true ifTrue: [^ 3] ifFalse: [^ 'should not be generated'].
	false ifTrue: [^ 'should not be generated'] ifFalse: [^ 4].

	true ifFalse: [^ 'should not be generated'] ifTrue: [^ 5].
	false ifFalse: [^ 6] ifTrue: [^ 'should not be generated'].
