projectServers
	"ServerDirectory projectServers"

	| projectServers projectServer |
	projectServers _ OrderedCollection new.
	self serverNames do: [ :n | 
		projectServer _ ServerDirectory serverNamed: n.
		(projectServer isProjectSwiki and: [projectServer isSearchable])
			ifTrue: [projectServers add: projectServer]].
	^projectServers