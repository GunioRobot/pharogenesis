buildMorphicPackagesList
	"Create the hierarchical list holding the packages and releases."

	^(SimpleHierarchicalListMorph 
		on: self
		list: #packageWrapperList
		selected: #selectedItemWrapper
		changeSelected: #selectedItemWrapper:
		menu: #packagesMenu:
		keystroke: nil)
		autoDeselect: false;
		enableDrag: false;
		enableDrop: true;
		setBalloonText: 'Here all packages with their releases are listed that should be displayed according the current filter.';
		yourself