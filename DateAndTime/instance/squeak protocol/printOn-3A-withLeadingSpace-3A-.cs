printOn: aStream withLeadingSpace: printLeadingSpaceToo
	"Print as per ISO 8601 sections 5.3.3 and 5.4.1.
	If printLeadingSpaceToo is false, prints either:
		'YYYY-MM-DDThh:mm:ss.s+ZZ:zz:z' (for positive years) or '-YYYY-MM-DDThh:mm:ss.s+ZZ:zz:z' (for negative years)
	If printLeadingSpaceToo is true, prints either:
		' YYYY-MM-DDThh:mm:ss.s+ZZ:zz:z' (for positive years) or '-YYYY-MM-DDThh:mm:ss.s+ZZ:zz:z' (for negative years)
	"

	self printYMDOn: aStream withLeadingSpace: printLeadingSpaceToo.
	aStream nextPut: $T.
	self printHMSOn: aStream.
	self nanoSecond ~= 0 ifTrue:
		[ | z ps |
		ps := self nanoSecond printString padded: #left to: 9 with: $0.
		z := ps findLast: [ :c | c asciiValue > $0 asciiValue ].
		(z > 0) ifTrue: [aStream nextPut: $.].
		ps from: 1 to: z do: [ :c | aStream nextPut: c ] ].
	aStream
		nextPut: (offset positive ifTrue: [$+] ifFalse: [$-]);
		nextPutAll: (offset hours abs asString padded: #left to: 2 with: $0);
		nextPut: $:;
		nextPutAll: (offset minutes abs asString padded: #left to: 2 with: $0).
	offset seconds = 0 ifFalse:
		[ aStream
			nextPut: $:;
			nextPutAll: (offset seconds abs truncated asString) ].
