addSubjectFilter
	"add a subject filter"

	| subject |
	mailDB ifNil: [^self].
	subject := self queryForSubjectFilterString.
	subject ifNil: [^self].
	self addFilter: (CelesteSubjectFilter forSubjectPattern: subject)