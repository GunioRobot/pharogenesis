toggleSubjectFilter
	"turn the subject filter on or off"
	subjectFilter ifNil: [
		| filterString |
		filterString := self queryForSubjectFilterString.
		filterString ifNil: [ ^self ].
		subjectFilter := CelesteSubjectFilter forSubjectPattern: filterString ]
	ifNotNil: [
		subjectFilter := nil ].

	self filtersChanged.
