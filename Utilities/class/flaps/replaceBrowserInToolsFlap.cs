replaceBrowserInToolsFlap
	self replacePartSatisfying: [:el |  (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented model isMemberOf: Browser]]]
inGlobalFlapSatisfying: [:f1 | f1 wording = 'Tools'] with:  ((Browser new openAsMorphEditing: nil) applyModelExtent setLabel: 'System Browser').

	self replacePartSatisfying: [:el |  (el isKindOf: MorphThumbnail) and: [(el morphRepresented isKindOf: SystemWindow) and: [el morphRepresented model isMemberOf: PackagePaneBrowser]]]
inGlobalFlapSatisfying: [:f1 | f1 wording = 'Tools'] with:  ((PackagePaneBrowser new openAsMorphEditing: nil) applyModelExtent setLabel: 'Package Browser')

