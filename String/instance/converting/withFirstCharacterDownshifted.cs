withFirstCharacterDownshifted
	"Answer an object like the receiver but with first character downshifted if necesary"

	"'MElViN' withFirstCharacterDownshifted"
	"#Will withFirstCharacterDownshifted"

	| answer |

	answer _ self asString.
	answer at: 1 put:
		(answer at: 1) asLowercase.
	^ answer as: self class