fileInProjectNamed: projectOrMemberName createView: aBoolean 
	"This is to be used from preamble/postscript code to file in SAR members 
	as Projects. 
	Answers the loaded project, or nil. 
	Does not enter the loaded project. 
	If aBoolean is true, also creates a ProjectViewMorph 
	(possibly in a window, depending on your Preferences)."
	| member project triple memberName |
	member _ self memberNamed: projectOrMemberName.
	member
		ifNotNil: [ memberName _ member fileName ]
		ifNil: [ 	member _ self memberNamed: (memberName _ self memberNameForProjectNamed: projectOrMemberName) ].
	member ifNil: [ ^self errorNoSuchMember: projectOrMemberName ].
	triple _ Project parseProjectFileName: memberName unescapePercents.
	project _ nil.
	[[ProjectLoading
		openName: triple first
		stream: member contentStream
		fromDirectory: nil
		withProjectView: nil]
		on: ProjectViewOpenNotification
		do: [:ex | ex resume: aBoolean]]
		on: ProjectEntryNotification
		do: [:ex | 
			project _ ex projectToEnter.
			ex resume].
	self installed: member.
	^ project