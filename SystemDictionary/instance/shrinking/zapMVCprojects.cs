zapMVCprojects   "Smalltalk zapMVCprojects"

	| window |
	Smalltalk garbageCollect.  "So allInstances is precise"
	Project allSubInstancesDo:
		[:proj |
		proj isTopProject
		ifTrue: [proj isMorphic ifFalse:
					["Root project is MVC -- we must become the root"
					Project current setParent: Project current]]
		ifFalse: [proj parent isMorphic
				ifFalse: [proj isMorphic ifTrue:
							["Remove Morphic projects from MVC views"
							"... and add them back here."
							window _ (SystemWindow labelled: proj name) model: proj.
							window addMorph: (ProjectViewMorph on: proj)
									frame: (0@0 corner: 1.0@1.0).
							window openInWorld.
							proj setParent: Project current]].
				proj isMorphic
					ifFalse: ["Remove MVC projects from Morphic views"
							Project allInstancesDo: [:p | p deletingProject: proj].
							ProjectViewMorph allInstancesDo: [:p | p deletingProject: proj]]]
		]