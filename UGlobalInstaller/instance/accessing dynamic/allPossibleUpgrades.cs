allPossibleUpgrades
	^ universe packageNames
		inject: OrderedCollection new
		into: [ :upgrades :name |
			(configuration includesPackageNamed: name)
			ifTrue: [| cpack mypack |
				cpack := configuration packageNamed: name.
				mypack := universe newestPackageNamed: name.
				(mypack version > cpack version)
					ifTrue: [upgrades add: mypack]].
				
				upgrades].