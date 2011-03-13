spawn: aString 
	"Create and schedule a fresh browser and place aString in its code pane.  This method is called when the user issues the #spawn command (cmd-o) in any code pane.  Whatever text was in the original code pane comes in to this method as the aString argument; the changes in the original code pane have already been cancelled by the time this method is called, so aString is the only copy of what the user had in his code pane."

	self selectedClassOrMetaClass ifNotNil: [^ super spawn: aString].

	systemCategoryListIndex ~= 0
		ifTrue:
			["This choice is slightly useless but is the historical implementation"
			^ self buildSystemCategoryBrowserEditString: aString].
		
	^ super spawn: aString  
	"This bail-out at least saves the text being spawned, which would otherwise be lost"