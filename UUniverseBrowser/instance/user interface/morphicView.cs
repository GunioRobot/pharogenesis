morphicView
	| win packageList installButton doInstallButton buttonList upgradeButton updateListButton descriptionArea installButtonHolder |
	win _ SystemWindow labelled: 'Universe'.
	win model: self.
		
	packageList _ 
		PluggableTreeMorph new
			model:  self;
			name: 'package list';
			getRootsSelector: #rootCategoriesAndPackages; 
			hasChildrenSelector: #isCategory:; 
			getChildrenSelector: #categoriesAndPackagesIn:;
			setSelectedSelector: #selectPackageOrCategory:;
			getLabelSelector: #packageOneLineDescription:.
	win addMorph: packageList frame: ((0@0) extent: (0.5@0.9)).
	
	installButtonHolder _ Morph new.  "necessary to keep SystemWindow from screwing up the colors of the button"
	installButtonHolder 
		name: 'holder for install button';
		layoutPolicy: TableLayout new;
		borderColor: self defaultBackgroundColor.
	doInstallButton _ self makeButtonWithAction: #doInstall andGetState: #anyPackagesToInstall andLabel: 'Install Selections'.
	doInstallButton
		useSquareCorners;
		borderWidth: 0;
		setBalloonText: 'Download and install all the packages that you have selected';
		name: 'install selections button'.
	installButtonHolder addMorph: doInstallButton.
	win addMorph: installButtonHolder frame: ((0@0.9) extent:(1@0.1)).

	descriptionArea _ PluggableTextMorph on: self text: #selectedPackageDescription accept: nil.
	win addMorph: descriptionArea frame: ((0.5@0.4) extent: (0.5@0.5)).
	
	buttonList _ AlignmentMorph newColumn.
	buttonList
		cellInset: 0@3;
		name: 'button list'.
	win addMorph: buttonList frame: ((0.5@0) extent: (0.5@0.4)).
		
	installButton _ self makeButtonWithAction: #installSelectedPackage andGetState: #canMarkSelectionForInstallation andLabel: 'select package'.
	installButton setBalloonText: 'Select this package for installation'.
	buttonList addMorph: installButton.
	
	upgradeButton _ self makeButtonWithAction: #chooseUpgrades andLabel: 'select all upgrades'.
	upgradeButton setBalloonText: 'Select every possible upgrade for the currently installed packages'.
	buttonList addMorphBack: upgradeButton.
	
	updateListButton _ self makeButtonWithAction: #requestPackageList andLabel: 'update list from network'.
	updateListButton setBalloonText: 'Refresh the list of available packages from the network'.
	buttonList addMorphBack: updateListButton.
	
	^win