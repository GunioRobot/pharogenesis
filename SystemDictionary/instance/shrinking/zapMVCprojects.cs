zapMVCprojects
	"Smalltalk zapMVCprojects"
	| window |

	self flag: #bob. "zapping projects"

	Smalltalk garbageCollect.
	"So allInstances is precise"
	Project
		allSubInstancesDo: [:proj | proj isTopProject
				ifTrue: [proj isMorphic
						ifFalse: ["Root project is MVC -- we must become the root"
							CurrentProjectRefactoring currentBeParentToCurrent]]
				ifFalse: [proj parent isMorphic
						ifFalse: [proj isMorphic
								ifTrue: ["Remove Morphic projects from MVC 
									views "
									"... and add them back here."
									window _ (SystemWindow labelled: proj name)
												model: proj.
									window
										addMorph: (ProjectViewMorph on: proj)
										frame: (0 @ 0 corner: 1.0 @ 1.0).
									window openInWorld.
									CurrentProjectRefactoring currentBeParentTo: proj]].
					proj isMorphic
						ifFalse: ["Remove MVC projects from Morphic views"
							Project deletingProject: proj]]]