addMandatoryClass: aClass
	"Add <aClass> as one of the SMObject types that I am mandatory for."

	mandatory ifNil: [mandatory _ Set new].
	mandatory add: aClass