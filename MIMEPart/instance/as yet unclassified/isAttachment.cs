isAttachment
	| field |
	field _ self fields at: 'content-disposition' ifAbsent: [^false].
	^'*attachment*' match: field