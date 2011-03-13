morphicView
	| win universeDescription buttonList usernameRow passwordRow button  usernamePasswordArea packageList |
	win _ SystemWindow labelled: 'Universe Editor'.
	win model: self.
	
	universeDescription := PluggableTextMorph on: self text: #universeDescription accept: nil.
	universeDescription hideScrollBarsIndefinitely.
	win addMorph: universeDescription frame: (0@0 extent: 1@0.1).
	
	buttonList _ AlignmentMorph newColumn.
	buttonList cellInset: 0@3.
	win addMorph: buttonList frame: (0@0.5 extent: 0.5@0.5).
	
	
	usernamePasswordArea _ AlignmentMorph newColumn.
	win addMorph: usernamePasswordArea frame: (0@0.1 extent: 0.5@0.4).

	usernameRow _ UInterfaceUtilities makeFieldRowNamed: 'username' getSelector: #username setSelector: #username: for: self.
	usernamePasswordArea addMorphBack: usernameRow.
	
	passwordRow _ UInterfaceUtilities makeFieldRowNamed: 'password:' getSelector: #password setSelector: #password: isPassword: true for: self.
	usernamePasswordArea addMorphBack: passwordRow.
	
	button _ self makeButtonWithAction: #createAccount andLabel: 'createAccount'.
	buttonList addMorphBack: button.
	button _ self makeButtonWithAction: #editAccount andLabel: 'edit account'.
	buttonList addMorphBack: button.
	button _ self makeButtonWithAction: #newPackage andLabel: 'new package'.
	buttonList addMorphBack: button.
	button _ self makeButtonWithAction: #newPackageVersion andGetState: #anyPackageSelected andLabel: 'new package version'.
	buttonList addMorphBack: button.
	button _ self makeButtonWithAction: #removeVersion andGetState: #anyPackageSelected andLabel: 'remove package version'.
	buttonList addMorphBack: button.
	button _ self makeButtonWithAction: #requestPackageList andLabel: 'update package list'.
	buttonList addMorphBack: button.

	packageList _ PluggableListMorph on: self list: #packageDescriptions  selected: #selectedPackageIndex changeSelected: #selectedPackageIndex: menu: nil.
	win addMorph: packageList frame: ((0.5@0.1) extent: (0.5@0.9)).

	
	^win