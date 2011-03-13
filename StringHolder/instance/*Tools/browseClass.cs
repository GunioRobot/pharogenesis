browseClass
	"Open an class browser on this class and method"

	self selectedClassOrMetaClass ifNotNil: [
		Browser newOnClass: self selectedClassOrMetaClass 
			selector: self selectedMessageName]