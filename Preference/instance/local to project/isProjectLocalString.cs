isProjectLocalString
	"Answer a string representing whether sym is a project-local preference or not"

	| aStr |
	aStr _  'each project has its own setting'.
	^ localToProject
		ifTrue:
			['<yes>', aStr]
		ifFalse:
			['<no>', aStr]