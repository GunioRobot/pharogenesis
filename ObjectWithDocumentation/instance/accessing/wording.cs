wording
	"Answer the receiver's wording"

	| wording |
	(wording := self propertyAt: #wording ifAbsent: [nil])
		ifNotNil: [^wording translated].

	self initWordingAndDocumentation.
	^self propertyAt: #wording ifAbsent: ['']