tasklistButtonFor: aTasklist
	"Answer a button for the task."
	
	^UITheme current
		newTasklistButtonIn: aTasklist
		for: self