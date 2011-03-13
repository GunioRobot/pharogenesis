putUpdate
	"Put this file out as an Update on the servers."

	| serverGroups index names |
	self canDiscardEdits ifFalse: [^ self changed: #flash].

	serverGroups _ ServerDirectory serverGroups.	"OC of associations"
	names _ serverGroups collect: [:each | each key].
	index _ (PopUpMenu labelArray: names lines: #()) 
		startUpWithCaption: 'Choose a group of servers to write on.'.
	index > 0 ifTrue: [
		(serverGroups at: index) value putUpdate: 
				(directory oldFileNamed: self fullName)].
