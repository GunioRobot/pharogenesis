removeFromCurrentChanges
	"Tell the changes mgr to forget that the current msg was changed."

	Smalltalk changes removeSelectorChanges: self selectedMessageName 
			class: self selectedClassOrMetaClass.