created: c updated: u name: n summary: s url: uu mandatory: m parentId: anId
	"Method used when recreating from storeOn: format.
	Note: That #addCategory: will set the parent variable."

	created _ c.
	updated _ u.
	name _ n.
	summary _ s.
	url _ uu.
	m ifTrue: [self addMandatoryClass: SMPackage].
	anId ifNotNil: [(map categoryWithId: anId) addCategory: self]