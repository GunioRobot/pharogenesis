reorganizeEverything
	"Undertake a grand reorganization.
	Environment reorganizeEverything.
	"

	| bigCat envt pool s |
	"First check for clashes between environment names and existing globals..."
	SystemOrganization categories do:
		[:cat | bigCat _ (cat asString copyUpTo: '-' first) asSymbol.
		(Smalltalk kernelCategories includes: bigCat) ifFalse:
			[(Smalltalk includesKey: bigCat) ifTrue:
				[^ self error: bigCat , ' cannot be used to name
both a package and a class or other global variable.
No reorganization will be attempted.']]].

	(self confirm:
'Your image is about to be partitioned into environments.
Many things may not work after this, so you should be
working in a throw-away copy of your working image.
Are you really ready to procede?
(choose ''no'' to stop here safely)')
		ifFalse: [^ self inform: 'No changes were made'].

	ChangeSet newChanges: (ChangeSet basicNewNamed: 'Reorganization').

	"Recreate the Smalltalk dictionary as the top-level Environment."
	Smalltalk at: #Smalltalk put: (SmalltalkEnvironment newFrom: Smalltalk).
	Smalltalk setName: #Smalltalk inOuterEnvt: nil.

	"Don't hang onto old copy of Smalltalk ."
	Smalltalk recreateSpecialObjectsArray.

	Smalltalk allClassesDo:
		[:c | c environment: nil. "Flush any old values"].

	"Run through all categories making up new sub-environments"
	SystemOrganization categories do:
		[:cat | bigCat _ (cat asString copyUpTo: '-' first) asSymbol.
		(Smalltalk kernelCategories includes: bigCat) ifFalse:
			["Not a kernel category ..."
			envt _ Smalltalk at: bigCat
						ifAbsent: ["... make up a new environment if necessary ..."
									Smalltalk makeSubEnvironmentNamed: bigCat].
			"... and install the member classes in that category"
			envt transferBindingsNamedIn: (SystemOrganization listAtCategoryNamed: cat)
									from: Smalltalk].
		].

	"Move all shared pools that are only referred to in sub environments"
	Smalltalk associationsDo:
		[:assn | ((pool _ assn value) isMemberOf: Dictionary) ifTrue:
			[s _ IdentitySet new.
			Smalltalk allClassesAnywhereDo:
				[:c | c sharedPools do:
					[:p | p == pool ifTrue:
						[s add: c environment]]].
			(s size = 1 and: [(envt _ s someElement) ~~ Smalltalk]) ifTrue:
				[envt declare: assn key from: Smalltalk]]].

	Smalltalk rewriteIndirectRefs.
	ChangeSet newChanges: (ChangeSet basicNewNamed: 'PostReorganization').
	ChangeSorter initialize.
	Preferences enable: #browserShowsPackagePane.

