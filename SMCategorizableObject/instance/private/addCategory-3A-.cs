addCategory: aCategory
	"Add <aCategory> to me. If I already have it do nothing."

	categories ifNil: [categories _ OrderedCollection new].
	(categories includes: aCategory) ifFalse:[
		aCategory addObject: self.
		categories add: aCategory].
	^aCategory