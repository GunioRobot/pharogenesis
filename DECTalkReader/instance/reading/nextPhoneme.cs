nextPhoneme
	| try try2 phon |
	try _ stream next asString.
	(',.;-' includes: try first) ifTrue: [^ phonemes at: 'sil'].
	try2 _ try, stream peek asString.
	(phon _ phonemes at: try2 ifAbsent: []) notNil ifTrue: [stream next. ^ phon].
	^ phonemes at: try