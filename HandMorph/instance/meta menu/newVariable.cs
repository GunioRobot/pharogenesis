newVariable

	| partName |
	partName _ owner model addPartNameLike: 'part' withValue: nil.
	partName ifNil: [^ self].  "user chose bad part name"
	owner model class compileAccessorsFor: partName