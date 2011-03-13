projectServers
	"ServerDirectory projectServers"

	| projectServers projectServer |
	projectServers := OrderedCollection new.
	self serverNames do: [ :n | 
		projectServer := ServerDirectory serverNamed: n.
		(projectServer isProjectSwiki and: [projectServer isSearchable])
			ifTrue: [projectServers add: projectServer]].
	^projectServers