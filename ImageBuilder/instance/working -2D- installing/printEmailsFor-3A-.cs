printEmailsFor: releases 
	"Print a list of emails for To:, this includes co-maintainers."
	| all first |
	all := Set new.
	releases
		do: [:rel | all addAll: (rel package maintainers asSet add: rel package owner;
					 yourself)].
	first := true.
	^ String
		streamContents: [:s | all
				do: [:acc | 
					first
						ifFalse: [s nextPutAll: ', '].
					s nextPutAll: acc nameAndEmail.
					first := false]]