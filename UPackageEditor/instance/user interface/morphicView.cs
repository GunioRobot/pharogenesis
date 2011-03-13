morphicView
	| win column nameRow versionRow urlRow descriptionField submitButton dependsRow homepageRow providesRow maintainerRow categoryRow smidRow |
	window ifNotNil: [ ^window ].
	win _ SystemWindow labelled: 'Package Editor'.
	win model: self.

	column _ AlignmentMorph newColumn.
	win addMorph: column frame: (0@0  extent:  1@0.6).
	

	nameRow _ UInterfaceUtilities makeFieldRowNamed: 'name:' getSelector: #packageName setSelector: #packageName: for: self.
	column addMorphBack: nameRow.
	

	versionRow _ UInterfaceUtilities makeFieldRowNamed: 'version:' getSelector: #versionString setSelector: #versionString: for: self.
	column addMorphBack: versionRow.
	
	categoryRow _ UInterfaceUtilities makeFieldRowNamed: 'category:' getSelector: #categoryString setSelector: #categoryString: for: self.
	column addMorphBack: categoryRow.
	
	maintainerRow _ UInterfaceUtilities makeFieldRowNamed: 'maintainer:' getSelector: #maintainer setSelector: #maintainer: for: self.
	column addMorphBack: maintainerRow.
	
	homepageRow _ UInterfaceUtilities makeFieldRowNamed: 'homepage:' getSelector: #homepageString setSelector: #homepageString: for: self.
	column addMorphBack: homepageRow.
	
	smidRow _ UInterfaceUtilities makeFieldRowNamed: 'SqueakMap ID:' getSelector: #smidString setSelector: #smidString: for: self.
	smidRow addMorphBack: self makeGuessSMIDButton.
	column addMorphBack: smidRow.
	

	
	urlRow _ UInterfaceUtilities makeFieldRowNamed: 'download from:' getSelector: #urlString setSelector: #urlString: for: self.
	column addMorphBack: urlRow.

	providesRow _ UInterfaceUtilities makeFieldRowNamed: 'provides:' getSelector: #providesString setSelector: #providesString: for: self.
	column addMorphBack: providesRow.
	
	dependsRow _ UInterfaceUtilities makeFieldRowNamed: 'depends:' getSelector: #dependsString setSelector: #dependsString: for: self.
	column addMorphBack: dependsRow.

	column addMorphBack: (StringMorph contents: 'Description:').
	
	descriptionField _ self makeFieldGet: #description set: #description:.
	win addMorph: descriptionField frame: (0@0.6 extent: 1@0.3).
	
	submitButton _ UInterfaceUtilities makeButtonWithAction: #submit andLabel: 'Submit' for: self.
	win addMorph: submitButton frame: (0@0.9 extent: 1@0.1).
	
	
	^window _ win