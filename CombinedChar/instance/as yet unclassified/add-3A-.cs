add: char

	| dict elem |
	codes ifNil: [codes _ Array with: char. combined _ char. ^ true].

	dict _ Compositions at: combined charCode ifAbsent: [^ false].

	elem _ dict at: combined charCode ifAbsent: [^ false].

	codes _ codes copyWith: char.
	combined _ elem.
	^ true.
