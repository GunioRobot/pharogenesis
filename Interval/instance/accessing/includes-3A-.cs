includes: aNumber
	"Determine if aNumber is an element of this interval."
	^ (self rangeIncludes: aNumber) and: [ self valuesInclude: aNumber ]