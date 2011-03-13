nextPhoneme
	| try try2 phon |
	try := stream next asString.
	(',.;-' includes: try first) ifTrue: [^ phonemes at: 'sil'].
	try2 := try, stream peek asString.
	(phon := phonemes at: try2 ifAbsent: []) notNil ifTrue: [stream next. ^ phon].
	^ phonemes at: try