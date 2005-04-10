sweep: aServerDirectory
	| repository list parts ind entry projectName versions |
	"On the server, move all but the three most recent versions of each Squeaklet to a folder called 'older'"
	"Project sweep: ((ServerDirectory serverNamed: 'DaniOnJumbo') clone 
				directory: '/vol0/people/dani/Squeaklets/2.7')"

	"Ensure the 'older' directory"
	(aServerDirectory includesKey: 'older') 
		ifFalse: [aServerDirectory createDirectory: 'older'].
	repository _ aServerDirectory clone directory: aServerDirectory directory, '/older'.

	"Collect each name, and decide on versions"
	list _ aServerDirectory fileNames.
	list isString ifTrue: [^ self inform: 'server is unavailable'].
	list _ list asSortedCollection asOrderedCollection.
	parts _ list collect: [:en | Project parseProjectFileName: en].
	parts _ parts select: [:en | en third = 'pr'].
	ind _ 1.
	[entry _ list at: ind.
		projectName _ entry first asLowercase.
		versions _ OrderedCollection new.  versions add: entry.
		[(ind _ ind + 1) > list size 
			ifFalse: [(parts at: ind) first asLowercase = projectName 
				ifTrue: [versions add: (parts at: ind).  true]
				ifFalse: [false]]
			ifTrue: [false]] whileTrue.
		aServerDirectory moveYoungest: 3 in: versions to: repository.
		ind > list size] whileFalse.
