buildWindow
"VMMakerTool openInWorld"
	| sysWin box verticalOffset |
	sysWin _ (SystemWindow labelled: 'VMMaker')
				model: self.

	verticalOffset _ 0.
	"add a row of buttons to start up various actions"
	box _ AlignmentMorph new vResizing: #shrinkWrap.
	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Generate All';
			 actionSelector: #generateAll;
			 hResizing: #spaceFill;
			 setBalloonText: 'Generate the sources for the core VM and all chosen plugins').
	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Generate Core VM';
			 actionSelector: #generateCore;
			 hResizing: #spaceFill;
			 setBalloonText: 'Generate the sources for the core vm and any internal plugins').

	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Generate External Plugins';
			 actionSelector: #generateExternal;
			 hResizing: #spaceFill;
			 setBalloonText: 'Generate the sources for all external plugins').
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0)
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset _ verticalOffset + box height - 1))).

	"add a row of buttons to start up various actions"
	box _ AlignmentMorph new vResizing: #shrinkWrap.
	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Load Configuration';
			 actionSelector: #loadConfig;
			 hResizing: #spaceFill;
			 setBalloonText: 'Load a previously saved configuration').
	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Save Configuration';
			 actionSelector: #saveConfig;
			 hResizing: #spaceFill;
			 setBalloonText: 'Save the current configuration').
	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Help';
			 actionSelector: #helpText;
			 hResizing: #spaceFill;
			 setBalloonText: 'Open the help window').
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0)
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset _ verticalOffset + box height - 1))).

	"add the labelled text field for the interpreter class name - 
	typically Interpreter"
	box _ AlignmentMorph new.
	box addMorph: (TextMorph new contents: 'Interpreter class name:' asText allBold) lock;
		 setBalloonText: 'The name of the Interpreter class'.
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 0.3 @ 0)
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset + box height - 1))).
	box _ AlignmentMorph new.
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (1 @ 0 corner: 1 @ 0)
				offsets: (-100 @ verticalOffset corner: 0 @ (verticalOffset + box height - 1))).
	sysWin
		addMorph: ((interpreterClassMorph _ PluggableTextMorph
				on: self
				text: #interpreterClassName
				accept: #interpreterClassName:)
				acceptOnCR: true)
		fullFrame: (LayoutFrame
				fractions: (0.3 @ 0 corner: 1 @ 0)
				offsets: (0 @ verticalOffset corner: -100 @ (verticalOffset _ verticalOffset + box height - 1))).

	"add the labelled text field for the path to the platform sources - 
	typically {current dir}/platforms"
	box _ AlignmentMorph new.
	box addMorph: (TextMorph new contents: 'Path to platforms code:' asText allBold) lock;
		 setBalloonText: 'The directory where the platform source tree is found; can be edited in text field to the right. Default of {working directory}/src is strongly recommended'.
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 0.3 @ 0)
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset + box height - 1))).
	box _ AlignmentMorph new.
	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Find Path';
			 actionSelector: #findPlatformsPath;
			 hResizing: #spaceFill;
			 setBalloonText: 'Choose the directory where you keep the platform specific code from a file dialogue').
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (1 @ 0 corner: 1 @ 0)
				offsets: (-100 @ verticalOffset corner: 0 @ (verticalOffset + box height - 1))).
	sysWin
		addMorph: ((platformPathMorph _ PluggableTextMorph
				on: self
				text: #platformsPathText
				accept: #platformsPathText:)
				acceptOnCR: true)
		fullFrame: (LayoutFrame
				fractions: (0.3 @ 0 corner: 1 @ 0)
				offsets: (0 @ verticalOffset corner: -100 @ (verticalOffset _ verticalOffset + box height - 1))).

	"add the labelled text field for the name of the platform - typically the 
	current platform"
	box _ AlignmentMorph new.
	box addMorph: (TextMorph new contents: 'Platform name:' asText allBold) lock;
		 setBalloonText: 'The platform name (as returned by Smalltalk platformName - unix, Mac OS, RISCOS, win32 etc); can be edited (in text field to the right) to cross generate'.
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 0.3 @ 0)
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset + box height - 1))).
	box _ AlignmentMorph new.
	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Find platform';
			 actionSelector: #platformsListMenu;
			 hResizing: #spaceFill;
			 setBalloonText: 'Choose from a list of known platforms. The default is this current platform.').
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (1 @ 0 corner: 1 @ 0)
				offsets: (-100 @ verticalOffset corner: 0 @ (verticalOffset + box height - 1))).
	sysWin
		addMorph: ((platformNameMorph _ PluggableTextMorph
				on: self
				text: #platformNameText
				accept: #platformNameText:)
				acceptOnCR: true)
		fullFrame: (LayoutFrame
				fractions: (0.3 @ 0 corner: 1 @ 0)
				offsets: (0 @ verticalOffset corner: -100 @ (verticalOffset _ verticalOffset + box height - 1))).

	"Add the labelled text field to specify where the generated code should 
	go; typically {current dir}/sources"
	box _ AlignmentMorph new.
	box addMorph: (TextMorph new contents: 'Path to generated sources' asText allBold;
			 lock);
		 setBalloonText: 'The directory where the built sources will be placed; can be edited in text field to the right. The default is strongly recommended; makefile alterations may be needed if you use a different path.'.
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 0.3 @ 0)
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset + box height - 1))).
	box _ AlignmentMorph new.
	box addMorphBack: (SimpleButtonMorph new target: self;
			 label: 'Clean out';
			 actionSelector: #cleanoutSrcDir;
			 hResizing: #spaceFill;
			 setBalloonText: 'Clean out all the files in the target directory, ready for a clean build').
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (1 @ 0 corner: 1 @ 0)
				offsets: (-100 @ verticalOffset corner: 0 @ (verticalOffset + box height - 1))).
	sysWin
		addMorph: ((generatedPathMorph _ PluggableTextMorph
				on: self
				text: #sourcePathText
				accept: #sourcePathText:)
				acceptOnCR: true)
		fullFrame: (LayoutFrame
				fractions: (0.3 @ 0 corner: 1 @ 0)
				offsets: (0 @ verticalOffset corner: -100 @ (verticalOffset _ verticalOffset + box height - 1))).

	"Add the list of plugins that are available to build"
	allPluginsList _ (PluggableListMorph
				on: self
				list: #availableModules
				selected: #currentAvailableModuleIndex
				changeSelected: #currentAvailableModuleIndex:
				menu: #availableListMenu:
				keystroke: nil) enableDragNDrop.
	allPluginsList hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 borderWidth: 0.
	box _ AlignmentMorph newColumn.
	box addMorphBack: (TextMorph new contents: 'Plugins not built' asText allBold;
			 lock);
		 setBalloonText: 'List of plugins that are available to build but not yet chosen. Drag to either other list or use menu option to move in bulk'.
	box addMorphBack: allPluginsList.
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 / 3 @ 1)
				offsets: (0 @ verticalOffset corner: 0 @ -100)).
	"make the list for plugins that will be built for internal linking"
	internalPluginsList _ (PluggableListMorph
				on: self
				list: #internalModules
				selected: #currentInternalModuleIndex
				changeSelected: #currentInternalModuleIndex:
				menu: #internalListMenu:
				keystroke: nil) enableDragNDrop.
	internalPluginsList hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 borderWidth: 0.
	box _ AlignmentMorph newColumn.
	box addMorphBack: (TextMorph new contents: 'Internal Plugins' asText allBold;
			 lock);
		 setBalloonText: 'List of plugins chosen to be built internally'.
	box addMorphBack: internalPluginsList.
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (1 / 3 @ 0 corner: 2 / 3 @ 1)
				offsets: (0 @ verticalOffset corner: 0 @ -100)).

	"make the list for plugins to be built externally (ie as DLLs, SO or 
	whatever suits the platform"
	externalPluginsList _ (PluggableListMorph
				on: self
				list: #externalModules
				selected: #currentExternalModuleIndex
				changeSelected: #currentExternalModuleIndex:
				menu: #externalListMenu:
				keystroke: nil) enableDragNDrop.
	externalPluginsList hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 borderWidth: 0.
	box _ AlignmentMorph newColumn.
	box addMorphBack: (TextMorph new contents: 'External Plugins' asText allBold;
			 lock);
		 setBalloonText: 'List of plugins chosen to be built externally'.
	box addMorphBack: externalPluginsList.
	sysWin
		addMorph: box
		fullFrame: (LayoutFrame
				fractions: (2 / 3 @ 0 corner: 1 @ 1)
				offsets: (0 @ verticalOffset corner: 0 @ -100)).
	sysWin
		addMorph: (PluggableTextMorph on: logger text: nil accept: nil
			readSelection: nil menu: nil)
		fullFrame: (LayoutFrame
				fractions: (0 @ 1 corner: 1 @ 1)
				offsets: (0 @ -100 corner: 0 @ 0)).
	^ sysWin