browseVersions
	"Create and schedule a Versions Browser, showing all versions of the 
	currently selected message. Answer the browser or nil."
	| selector class | 
	self classCommentIndicated
		ifTrue: [ ClassCommentVersionsBrowser browseCommentOf: self selectedClass.
			^nil ].

	(selector _ self selectedMessageName)
		ifNil:[ self inform: 'Sorry, only actual methods have retrievable versions.'. ^nil ]
		ifNotNil: [
			class _ self selectedClassOrMetaClass.
			^VersionsBrowser
				browseVersionsOf: (class compiledMethodAt: selector)
				class: self selectedClass
				meta: class isMeta
				category: (class organization categoryOfElement: selector)
				selector: selector]