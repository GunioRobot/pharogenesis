stemUrl: aUrlString
	"Peel off the 'x5.sp'  or '.bo' from the end of a url of a SqueakPage or a BookMorph index file"

	| ll aUrl |
	ll _ aUrlString findLast: [:char | char == $.].
	ll = 0 
		ifTrue: [aUrl _ aUrlString]
		ifFalse: [aUrl _ aUrlString copyFrom: 1 to: ll-1].	"remove .sp"
	aUrl _ (aUrl stemAndNumericSuffix) at: 1.
			"remove trailing number"
	aUrl size = 0 ifTrue: [^ aUrl].	"empty"
	[aUrl last == $x] whileTrue: [aUrl _ aUrl allButLast].
	^ aUrl