printOn: aStream
	"Format as per ANSI 5.8.2.16: [-]D:HH:MM:SS[.S]" 	| d h m s n |
	d _ self days abs.
	h _ self hours abs.
	m _ self minutes abs.
 	s _ self seconds abs truncated.
	n _ self nanoSeconds abs. 	self negative ifTrue: [ aStream nextPut: $- ].
	d printOn: aStream. aStream nextPut: $:.
	h < 10 ifTrue: [ aStream nextPut: $0. ].
	h printOn: aStream. aStream nextPut: $:.
	m < 10 ifTrue: [ aStream nextPut: $0. ].
	m printOn: aStream. aStream nextPut: $:.
	s < 10 ifTrue: [ aStream nextPut: $0. ].
	s printOn: aStream.
	n = 0 ifFalse:
		[ | z ps |
		aStream nextPut: $..
		ps _ n printString padded: #left to: 9 with: $0. 
		z _ ps findLast: [ :c | c asciiValue > $0 asciiValue ].
		ps from: 1 to: z do: [ :c | aStream nextPut: c ] ].
