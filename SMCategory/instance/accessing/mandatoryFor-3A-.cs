mandatoryFor: aClass
	"Is this category mandatory for instances of <aClass>?"

	^mandatory ifNil: [false] ifNotNil: [mandatory includes: aClass]