setGridSpec
	"Gridding rectangle provides origin and modulus"
	| response result mx |
	mx _ 36.  "... because it was that way before ..."
	response _ FillInTheBlank
			request: 'New grid origin (usually 0@0):'
			initialAnswer: self gridOrigin printString.
	response isEmpty ifTrue: [^ self].
	result _ [Compiler evaluate: response] ifError: [^ self].
	(result isPoint and: [(result >= (0@0)) & (result < (mx @ mx))])
		ifTrue: [self gridOrigin: result]
		ifFalse: [self inform: 'Must be a Point with coordinates between 0 & '
								, (mx-1) printString].

	response _ FillInTheBlank
			request: 'New grid spacing:'
			initialAnswer: self gridModulus printString.
	response isEmpty ifTrue: [^ self].
	result _ [Compiler evaluate: response] ifError: [^ self].
	(result isPoint and: [(result > (0@0)) & (result <= (mx @ mx))])
		ifTrue: [self gridModulus: result]
		ifFalse: [self inform: 'Must be a Point with coordinates between 1 & '
								, mx printString].

