forget
	"Drop this method from the changeSet"
	listIndex = 0 ifTrue: [^ self].
	parent changeSet removeSelectorChanges: parent selectedMessageName 
			class: parent selectedClassOrMetaClass.
	parent launch.