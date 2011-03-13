rule10
	"Rule 10: Shortening in clusters."
	| current next previous stream |
	phrase lastSyllable == syllable ifTrue: [^ self].
	stream := ReadStream on: syllable events.
	current := nil.
	next := stream next.
	[stream atEnd]
		whileFalse: [previous := current.
					current := next.
					next := stream next.
					current phoneme isVowel
						ifTrue: [next phoneme isVowel
									ifTrue: [current stretch: 1.2]
									ifFalse: [(previous notNil and: [previous phoneme isVowel])
												ifTrue: [current stretch: 0.7]]]
						ifFalse: [next phoneme isConsonant
									ifTrue: [(previous notNil and: [previous phoneme isConsonant])
												ifTrue: [current stretch: 0.5]
												ifFalse: [current stretch: 0.7]]
									ifFalse: [(previous notNil and: [previous phoneme isConsonant])
												ifTrue: [current stretch: 0.5]]]]