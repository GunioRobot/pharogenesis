widthOf: aCharacter 
	"Answer the width of the argument as a character in the receiver."
	"1: optimizing"
	| encoding f |
	aCharacter class == Character
		ifTrue: [^ (fontArray at: 1)
				widthOf: aCharacter].
	"2: other case"
	encoding := aCharacter leadingChar + 1.
	f := ((((aCharacter isMemberOf: Character) not
							and: [encoding > 1])
						and: [encoding <= fontArray size])
					and: [(fontArray at: encoding) notNil])
				ifTrue: [fontArray at: encoding]
				ifFalse: [self latin1].
	^ f widthOf: aCharacter