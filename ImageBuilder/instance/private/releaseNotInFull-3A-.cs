releaseNotInFull: rel

	| basic full |
	basic := SMSqueakMap default categoryWithId: 'af36d60e-6066-4d68-bae0-90c459f5b9d8'.
	full _ SMSqueakMap default categoryWithId: '3a184d3f-be1e-46cc-89b0-bd8798853ff7'.
	^((rel hasCategory: basic) or: [rel package hasCategory: basic])
		and:[((rel hasCategory: full) or: [rel package hasCategory: full]) not]