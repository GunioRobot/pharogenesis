saveFormsOn: aStream

	| rr |
	rr _ ReferenceStream on: aStream.
	rr nextPut: {id isoString. generics}.
	rr close.
