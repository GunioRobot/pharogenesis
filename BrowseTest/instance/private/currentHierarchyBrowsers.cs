currentHierarchyBrowsers
	^ (ActiveWorld submorphs
		select: [:each | (each isKindOf: SystemWindow)
				and: [each model isKindOf: HierarchyBrowser]]) asSet