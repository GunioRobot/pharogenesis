calculateShouldBeFrom2ndLevel: item using: c
	| shouldBe indexOf temp |
	
	shouldBe := item size < 3
			ifTrue: [item copyReplaceAll: c with: ' '.
					item copyReplaceAll: '(' with: ' '.]
			ifFalse: [(c = '(')
				ifTrue: [
					indexOf := item indexOf: $(.
					[((item at: indexOf) = $( and: [(item at: indexOf + 2) = $)])
						ifTrue: 
							[temp := item copy.
							((item at: indexOf + 1) = Character space or: [(item at: indexOf + 1) = $(])
								ifTrue: [temp at: indexOf put: Character space]
								ifFalse: [temp at: indexOf put: $/].
							temp at: indexOf + 2 put: Character space.
							temp]
						ifFalse: [temp := item copy.
								temp at: indexOf put: Character space].
								temp] 
							ifError: [temp := item copy.
									temp at: indexOf put: Character space.
									temp]]
				ifFalse: [item copyReplaceAll: c with: ' ']].
	(shouldBe indexOf: $() > 0 
		ifTrue: [shouldBe = '(' ifTrue: [self halt]. 
				^self calculateShouldBeFrom2ndLevel: shouldBe using: '('].
	^shouldBe