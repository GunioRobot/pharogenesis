removeMandatoryClass: aClass
	"Remove <aClass> as one of the SMObject types that I am mandatory for."

	mandatory ifNotNil: [mandatory remove: aClass ifAbsent: [^nil]]