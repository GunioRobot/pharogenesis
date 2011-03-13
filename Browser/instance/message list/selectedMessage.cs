selectedMessage
	"Answer a copy of the source code for the selected message selector."

	contents == nil 
		ifTrue: [contents _ 
					self selectedClassOrMetaClass 
						sourceCodeAt: self selectedMessageName].
	^contents copy