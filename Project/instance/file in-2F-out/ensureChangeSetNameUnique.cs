ensureChangeSetNameUnique

	| myName |

	myName _ self name.
	Project allProjects do: [:pp | 
		pp == self ifFalse: [
			(pp name = myName and: [pp projectChangeSet ~~ changeSet]) ifTrue: [
				(pp parameterAt: #loadingNewerVersion ifAbsent: [false]) ifTrue: [
					pp projectParameters at: #loadingNewerVersion put: false.
				] ifFalse: [
					changeSet ifNil: [^ changeSet _ ChangeSet new].
					^changeSet name: (ChangeSet uniqueNameLike: myName)
				].
			]
		]
	]
