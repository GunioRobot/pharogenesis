lastRemoval  "Smalltalk lastRemoval" 
	#(abandonSources browseAllSelect: printSpaceAnalysis browseObsoleteReferences  lastRemoval) do:
		[:sel | SystemDictionary removeSelector: sel].
	[self removeAllUnSentMessages > 0] whileTrue.
	Set withAllSubclassesDo:
		[:cls | cls allInstances do: [:s | s rehash]].
	Smalltalk allClassesDo: [:c | c zapOrganization].
	Smalltalk changes initialize.