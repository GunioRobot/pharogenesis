findProjectView: projectDescription
	| pName dpName proj |
	"In this world, find the morph that holds onto the project described by projectDescription.  projectDescription can be a project, or the name of a project.  The project may be represented by a DiskProxy.  The holder morph may be at any depth in the world.
	Need to fix this if Projects have subclasses, or if a class other than ProjectViewMorph can officially hold onto a project.  (Buttons, links, etc)
	If parent is an MVC world, return the ProjectController."

	self flag: #bob.		"read the comment"


	pName _ (projectDescription isString) 
		ifTrue: [projectDescription]
		ifFalse: [projectDescription name].
	self isMorphic 
		ifTrue: [world allMorphsDo: [:pvm |
				pvm class == ProjectViewMorph ifTrue: [
					(pvm project class == Project and: 
						[pvm project name = pName]) ifTrue: [^ pvm].

					pvm project class == DiskProxy ifTrue: [ 
						dpName _ pvm project constructorArgs first.
						dpName _ (dpName findTokens: '/') last.
						dpName _ (Project parseProjectFileName: dpName unescapePercents) first.
						dpName = pName ifTrue: [^ pvm]]]]]
		ifFalse: [world scheduledControllers do: [:cont |
				(cont isKindOf: ProjectController) ifTrue: [
					((proj _ cont model) class == Project and: 
						[proj name = pName]) ifTrue: [^ cont view].

					proj class == DiskProxy ifTrue: [ 
						dpName _ proj constructorArgs first.
						dpName _ (dpName findTokens: '/') last.
						dpName _ (Project parseProjectFileName: dpName unescapePercents) first.
						dpName = pName ifTrue: [^ cont view]]]]
			].
	^ nil