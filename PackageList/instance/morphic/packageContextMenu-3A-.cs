packageContextMenu: aMenu
	aMenu
		addLine;
		add: 'remove package' action: #removePackage;
		addServices: PackageServices allServices for: selectedPackage extraLines: #()