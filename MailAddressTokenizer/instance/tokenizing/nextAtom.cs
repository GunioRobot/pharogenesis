nextAtom
	| start end |
	start _ pos.
	pos _ text indexOfAnyOf: CSNonAtom startingAt: start ifAbsent: [ text size + 1].
	end _ pos - 1.
	^MailAddressToken
		type: #Atom
		text: (text copyFrom: start to: end)