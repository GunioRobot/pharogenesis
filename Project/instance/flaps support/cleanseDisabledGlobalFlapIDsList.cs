cleanseDisabledGlobalFlapIDsList
	"Make certain that the items on the disabled-global-flap list are actually global flaps, and if not, get rid of them"

	| disabledFlapIDs currentGlobalIDs oldList |
	Smalltalk isMorphic ifTrue:
		[disabledFlapIDs _ self parameterAt: #disabledGlobalFlapIDs ifAbsent: [Set new].
		currentGlobalIDs _ Flaps globalFlapTabsIfAny collect: [:f | f flapID].
		oldList _ Project current projectParameterAt: #disabledGlobalFlaps ifAbsent: [nil].
		oldList ifNotNil:
			[disabledFlapIDs _ oldList select: [:aFlap | aFlap flapID]].
		disabledFlapIDs _ disabledFlapIDs select: [:anID | currentGlobalIDs includes: anID].
		self projectParameterAt: #disabledGlobalFlapIDs put: disabledFlapIDs].

	projectParameters ifNotNil:
		[projectParameters removeKey: #disabledGlobalFlaps ifAbsent: []].
