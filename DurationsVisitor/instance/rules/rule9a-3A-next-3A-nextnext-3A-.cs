rule9a: current next: next nextnext: nextnext
	"Rule 9a: Postvocalic context of vowels."

	current isVowel
		ifTrue: [next isNil ifTrue: [^ 1.2].
				nextnext isNil ifTrue: [^ self subRule9a: next].
				(next isSonorant and: [nextnext isObstruent]) ifTrue: [^ self subRule9a: nextnext]]
		ifFalse: [current isSonorant
					ifTrue: [next isNil ifTrue: [^ 1.2].
							next isObstruent ifTrue: [^ self subRule9a: next]]].
	^ 1.0