replaceBrowserInToolsFlap
	self replacePartSatisfying: [:el |  (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented model isMemberOf: Browser]]]
inGlobalFlapSatisfying: [:f1 | f1 wording = 'Tools'] with:  ((Browser new openAsMorphEditing: nil) applyModelExtent setLabel: 'System Browser').

	self replacePartSatisfying: [:el |  (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented model isMemberOf: PackageBrowser]]]
inGlobalFlapSatisfying: [:f1 | f1 wording = 'Tools'] with:  ((PackageBrowser new openAsMorphEditing: nil) applyModelExtent setLabel: 'Package Browser')

